using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public class Extra
    {
        public GameObject hitmarker, cam;

        public Vector3 bloom, recoil;

        public float bloomMain, fovMain;

        public TextMeshProUGUI AmmoText;

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

<<<<<<< Updated upstream
        extra.AmmoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        extra.AmmoText.text = ammoCount.ToString() + "/" + startAmmo;
=======
        stats.accurate = stats.hit / stats.fired * 100;
        extra.startAmmo = ammoCount;

        extra.ammoText = GameObject.Find("AmmoText").GetComponent<TextMeshProUGUI>();
        extra.ammoText.text = ammoCount.ToString() + "/" + extra.startAmmo;
        extra.aim = GameObject.Find("Accurate").GetComponent<TextMeshProUGUI>();
        extra.aim.text = "100" + "%";
>>>>>>> Stashed changes
        extra.cam = GameObject.Find("Main Camera");
        extra.fovMain = extra.cam.GetComponent<Camera>().fieldOfView;
        extra.hitmarker = GameObject.Find("HitMarker");

<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
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

            print(hit.transform.name);
            Destroy(hit.transform.gameObject);
        }

        stats.accurate = stats.hit / stats.fired * 100;

        print(stats.accurate);
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
        extra.AmmoText.text = ammoCount.ToString() + "/" + startAmmo;

        extra.AmmoText.color = Color.black;
    }
}
