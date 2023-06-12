using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseGun : MonoBehaviour
{
    public class Extra
    {
        public GameObject hitmarker, cam;

        public Vector3 bloom, recoil;

        public float bloomMain, fovMain;

        public int startAmmo;

        public TextMeshProUGUI ammoText, aim;

        public float timer;

        public bool infiniteAmmo, reload;
    }

    public class ShootingStats
    {
        public float fired, hit, accurate;
    }

    //Public

    public string nameWeapon;
    public int ammoCount, maxDistance, damage;
    public float bloomRange, shootDelay, recoilMain, zoom;
    public AmmoType ammoType;

    public enum AmmoType
    {
        light,
        heavy,
        shotgun,
        sniper,
    }

    //Private

    private GameObject ADSloc, hipfireLoc, infiniteAmmoIcon;

    private Movement player;

    public Extra extra;
    public ShootingStats stats;
    private AudioSource shoot;

    private void Start()
    {
        extra = new Extra();
        stats = new ShootingStats();

        stats.accurate = stats.hit / stats.fired * 100;

        extra.startAmmo = ammoCount;

        extra.ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

        extra.aim = GameObject.Find("Accurate").GetComponent<TextMeshProUGUI>();
        extra.aim.text = "100" + "%";

        extra.cam = GameObject.Find("Main Camera");
        extra.fovMain = extra.cam.GetComponent<Camera>().fieldOfView;
        extra.hitmarker = GameObject.Find("HitMarker");
        extra.hitmarker.SetActive(false);

        extra.startAmmo = ammoCount;

        player = GameObject.Find("Player").GetComponent<Movement>();
        ADSloc = GameObject.Find("ADS");
        hipfireLoc = GameObject.Find("Hand");
        infiniteAmmoIcon = GameObject.Find("infiniteAmmo");

        shoot = GetComponent<AudioSource>();
    }

    private void Update()
    {
        extra.timer += Time.deltaTime;

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
        int Target = 1 << 6;

        stats.fired += 1;

        extra.bloom = extra.cam.transform.position + extra.cam.transform.forward * 100;
        extra.bloom += Random.Range(-extra.bloomMain, extra.bloomMain) * extra.cam.transform.up;
        extra.bloom += Random.Range(-extra.bloomMain, extra.bloomMain) * extra.cam.transform.right;
        extra.bloom -= extra.cam.transform.position;
        extra.bloom.Normalize();

        shoot.Play();

        RaycastHit hit;

        if(Physics.Raycast(extra.cam.transform.position, extra.bloom, out hit, maxDistance, Target))
        {
            stats.hit += 1;

            Hit();

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
            }

            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<ZombieAI>().hp -= damage;
            }
        }

        stats.accurate = (int)(stats.hit / stats.fired * 100);

        extra.aim.text = stats.accurate.ToString() + "%";
    }

    public async void Hit()
    {
        extra.hitmarker.SetActive(true);

        await Task.Delay(200);

        extra.hitmarker.SetActive(false);
    }

    public virtual void ADS()
    {
        transform.SetParent(ADSloc.transform);
        transform.localScale = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    public virtual void Normal()
    {
        transform.SetParent(hipfireLoc.transform);
        transform.localScale = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    public virtual async void Reload()
    {
        extra.reload = true;
        await Task.Delay(1000);

        print("Base reload");
        ammoCount = extra.startAmmo;
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;

        extra.ammoText.color = Color.black;
        extra.reload = false;
    }
}
