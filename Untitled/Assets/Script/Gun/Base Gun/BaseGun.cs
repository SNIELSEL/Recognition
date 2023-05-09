using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : MonoBehaviour
{
    public string nameWeapon;
    public int startAmmo, ammoCount, maxDistance, damage, burstShot, test2;
    public float bloomRange, shootDelay, timer, recoilADS, recoilHIP, recoilMain, burstShotTimer, zoom;

    public GameObject hitmarker, weaponADS, weapon;

    public GameObject cam, ADSloc;
    public Vector3 bloom, recoil;

    public float bloomMain, fovMain;
    public Movement player;

    public AmmoType ammoType;

    public enum AmmoType
    {
        light,
        heavy,
        shotgun,
        sniper,
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera Shooting");
        fovMain = cam.GetComponent<Camera>().fieldOfView;
        player = GameObject.Find("Player Shooting").GetComponent<Movement>();
        ADSloc = GameObject.Find("ADS");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        burstShotTimer += Time.deltaTime;
    }

    public virtual void Shoot()
    {
        timer = 0;
        burstShotTimer = 0;
        int Target = 1 << 6;

        bloom = cam.transform.position + cam.transform.forward * 100;
        bloom += Random.Range(-bloomMain, bloomMain) * cam.transform.up;
        bloom += Random.Range(-bloomMain, bloomMain) * cam.transform.right;
        bloom -= cam.transform.position;
        bloom.Normalize();

        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, bloom, out hit, maxDistance, Target))
        {
            //Instantiate(hitmarker, hit.point, cam.transform.rotation);

            print(hit.transform.name);
        }
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
    }
}
