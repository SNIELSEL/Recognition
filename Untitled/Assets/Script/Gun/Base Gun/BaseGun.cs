using TMPro;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public class Extra
    {
        public GameObject hitmarker, cam;

        public Vector3 bloom, recoil;

        public float bloomMain, fovMain;

        public TextMeshProUGUI ammoText, aim;

        public float timer;
    }

    public class ShootingStats
    {
        public float fired, hit, accurate;
    }

    //Public

    public string nameWeapon;
    public int startAmmo, ammoCount, maxDistance, damage;
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

    private GameObject ADSloc;

    private Movement player;

    public Extra extra;
    public ShootingStats stats;

    private void Start()
    {
        extra = new Extra();
        stats = new ShootingStats();

        stats.accurate = stats.hit / stats.fired * 100;

        extra.ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        extra.ammoText.text = ammoCount.ToString() + "/" + startAmmo;
        extra.aim = GameObject.Find("Accurate").GetComponent<TextMeshProUGUI>();
        extra.aim.text = "100" + "%";
        extra.cam = GameObject.Find("Main Camera");
        extra.fovMain = extra.cam.GetComponent<Camera>().fieldOfView;
        extra.hitmarker = GameObject.Find("HitMarker");


        player = GameObject.Find("Player").GetComponent<Movement>();
        ADSloc = GameObject.Find("ADS");
    }

    private void Update()
    {
        extra.timer += Time.deltaTime;
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

        RaycastHit hit;

        if(Physics.Raycast(extra.cam.transform.position, extra.bloom, out hit, maxDistance, Target))
        {
            stats.hit += 1;

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
        }

        stats.accurate = (int)(stats.hit / stats.fired * 100);

        extra.aim.text = stats.accurate.ToString() + "%";
    }

    public virtual void ADS()
    {

    }

    public virtual void Normal()
    {

    }

    public virtual void Reload()
    {
        print("Base reload");
        ammoCount = startAmmo;
        extra.ammoText.text = ammoCount.ToString() + "/" + startAmmo;

        extra.ammoText.color = Color.black;
    }
}
