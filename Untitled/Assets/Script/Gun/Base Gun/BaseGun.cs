using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseGun : MonoBehaviour
{
    public class Extra
    {
        public GameObject hitmarker, cam, reloadText;

        public Vector3 bloom, recoil;

        public float fovMain;

        public int startAmmo;

        public TextMeshProUGUI ammoText, aim;

        public float timer;

        public bool infiniteAmmo, reload;

        public AudioSource reloadSound;
    }

    public class ShootingStats
    {
        public float fired, hit, accurate;
    }

    public class Upgrade
    {
        public float reloadBoosted, damageBoosted, ammoBoosted;
    }

    //Public

    public string nameWeapon;
    public int ammoCount, maxDistance, damage, reloadTime;
    public float bloomRange, shootDelay, recoilMain, zoom;
    public AmmoType ammoType;
    public AudioSource hitSound;

    public GameObject inpact, HitSoundObject;

    public enum AmmoType
    {
        light,
        heavy,
        shotgun,
        sniper,
    }

    //Private

    private bool ads;

    private GameObject ADSloc, hipfireLoc, infiniteAmmoIcon;

    private Movement player;
    private InGameMenuController inMenuCheck;

    public Extra extra;
    public ShootingStats stats;
    public Upgrade upgrade;

    private AudioSource shoot;
    private ParticleSystem flash;
    private WeaponShake shake;
    private float fov;


    private void Awake()
    {
        extra = new Extra();
        stats = new ShootingStats();
        upgrade = new Upgrade();

        stats.accurate = stats.hit / stats.fired * 100;
        extra.startAmmo = ammoCount;

        extra.reloadSound = GameObject.Find("ReloadSound").GetComponent<AudioSource>();

        extra.ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

        extra.aim = GameObject.Find("Accurate").GetComponent<TextMeshProUGUI>();
        extra.aim.text = "100" + "%";

        extra.cam = GameObject.Find("Main Camera");
        extra.fovMain = extra.cam.GetComponent<Camera>().fieldOfView;
        extra.hitmarker = GameObject.Find("HitMarker");
        //extra.hitmarker.SetActive(false);

        extra.startAmmo = ammoCount;

        player = GameObject.Find("Player").GetComponent<Movement>();
        ADSloc = GameObject.Find("ADS");
        hipfireLoc = GameObject.Find("Hand");
        infiniteAmmoIcon = GameObject.Find("infiniteAmmo");

        shoot = GetComponent<AudioSource>();
        flash = GameObject.Find("Flash").GetComponent<ParticleSystem>();
        shake = GetComponent<WeaponShake>();

        fov = extra.cam.GetComponent<Camera>().fieldOfView;

        extra.reloadText = GameObject.Find("ReloadText");
        inMenuCheck = GameObject.Find("Keep1").GetComponent<InGameMenuController>();

        extra.reloadText.GetComponent<TextMeshProUGUI>().enabled = false;

        upgrade.ammoBoosted = extra.startAmmo;
        upgrade.damageBoosted = damage;
        upgrade.reloadBoosted = reloadTime;
    }

    private void OnEnable()
    {
        extra.ammoText.text = ammoCount.ToString() + "/" + (int) upgrade.ammoBoosted;
    }

    private void Update()
    {
        extra.timer += Time.deltaTime;

        if(GameObject.Find("Upgrades") != null)
        {
            upgrade.ammoBoosted = GameObject.Find("Upgrades").GetComponent<UpgradeManage>().ammoBoost * extra.startAmmo;
            upgrade.damageBoosted = GameObject.Find("Upgrades").GetComponent<UpgradeManage>().damageBoost * damage;
            upgrade.reloadBoosted = reloadTime / GameObject.Find("Upgrades").GetComponent<UpgradeManage>().reloadBoost;
        }

        /*
         
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (extra.infiniteAmmo == false)
            {
                extra.infiniteAmmo = true;
                infiniteAmmoIcon.GetComponent<Toggle>().isOn = true;
            }

            else if (extra.infiniteAmmo == true)
            {
                extra.infiniteAmmo = false;
                infiniteAmmoIcon.GetComponent<Toggle>().isOn = false;
            }
        }

        */
    }

    public virtual void Shoot()
    {
        extra.timer = 0;
        stats.fired += 1;

        shoot.Play();
        flash.Play();

        if(ads == false)
        {
            shake.Shake();

            extra.bloom = extra.cam.transform.position + extra.cam.transform.forward * 100;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.up;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.right;
            extra.bloom -= extra.cam.transform.position;
            extra.bloom.Normalize();
        }

        else
        {
            extra.bloom = extra.cam.transform.forward;
        }


        if (transform.GetComponent<Shotgun>() == true)
        {
            extra.bloom = extra.cam.transform.position + extra.cam.transform.forward * 100;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.up;
            extra.bloom += Random.Range(-bloomRange, bloomRange) * extra.cam.transform.right;
            extra.bloom -= extra.cam.transform.position;
            extra.bloom.Normalize();
        }

        RaycastHit hit;
        

        if(Physics.Raycast(extra.cam.transform.position, extra.bloom, out hit, maxDistance))
        {
            Instantiate(inpact, hit.point, transform.rotation);

            if (hit.transform.parent.tag == "targets")
            {
                if (hit.transform.tag == "tile")
                {
                    hit.transform.GetComponent<Tile>().Hit();
                }

                if (hit.transform.tag == "Falling")
                {
                    hit.transform.GetComponent<Falling>().Hit();
                }

                Hit();
                stats.hit += 1;
            }

            if (hit.transform.tag == "Enemy")
            {
                Instantiate(HitSoundObject , hit.point, transform.rotation);

                hit.transform.GetComponent<ZombieAI>().hp -= upgrade.damageBoosted;

                Hit();
                stats.hit += 1;
            }
        }

        stats.accurate = (int)((stats.hit / stats.fired) * 50);

        extra.aim.text = stats.accurate.ToString() + "%";
    }

    public async void Hit()
    {
        extra.hitmarker.GetComponent<RawImage>().enabled = true;

        await Task.Delay(100);

        extra.hitmarker.GetComponent<RawImage>().enabled = false;
    }

    public virtual void ADS()
    {
        if (!inMenuCheck.inMenu)
        {
            transform.SetParent(ADSloc.transform);
            transform.localScale = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            extra.bloom = Vector3.zero;
            
            ads = true;

            GameObject.Find("WeaponCam").GetComponent<Camera>().fieldOfView = fov / zoom;
            extra.cam.GetComponent<Camera>().fieldOfView = fov / zoom;

            GameObject.Find("Player").GetComponent<Movement144>().extraS.zoom = zoom;
        }
    }

    public virtual void Normal()
    {
        transform.SetParent(hipfireLoc.transform);
        transform.localScale = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;

        ads = false;

        GameObject.Find("WeaponCam").GetComponent<Camera>().fieldOfView = fov;
        extra.cam.GetComponent<Camera>().fieldOfView = fov;

        GameObject.Find("Player").GetComponent<Movement144>().extraS.zoom = 1;
    }

    public virtual async void Reload()
    {
        extra.reloadSound.pitch = 0.6f / (upgrade.reloadBoosted / reloadTime);
        extra.reloadSound.Play();

        extra.reload = true;
        await Task.Delay((int) upgrade.reloadBoosted);

        ammoCount = (int) upgrade.ammoBoosted;
        extra.ammoText.text = ammoCount.ToString() + "/" + (int) upgrade.ammoBoosted;

        extra.ammoText.color = new Color (0,143,255);
        extra.reload = false;

        extra.reloadText.GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
