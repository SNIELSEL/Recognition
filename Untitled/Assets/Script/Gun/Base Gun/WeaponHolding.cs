using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolding : MonoBehaviour
{
    public GameObject weaponSlot1, weaponSlot2, auto, single, shotgun, sniper, burst, akimbo, vector;
    public KeyCode weapon1, weapon2, weapon3;
    private float weaponholding;

    private void Start()
    {
        weaponholding = 1;
    }

    private void Update()
    {
        if (weaponholding == 0)
        {
            weaponSlot1.SetActive(false);
            weaponSlot2.SetActive(false);
        }

        if (weaponholding == 1) 
        {
            weaponSlot1.SetActive(true);
            weaponSlot2.SetActive(false);
        }

        if (weaponholding == 2)
        {
            weaponSlot1.SetActive(false);
            weaponSlot2.SetActive(true);
        }
        
        if (Input.GetKeyDown(weapon1))
        {
            weaponholding = 1;
        }

        if (Input.GetKeyDown(weapon2))
        {
            weaponholding = 2;
        }

        if (Input.GetKeyDown(weapon3))
        {
            weaponholding = 0;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponScrol();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponScrol();
        }
    }

    public void weaponScrol()
    {
        if (weaponholding == 1)
        {
            weaponholding = 2;
        }

        else if (weaponholding == 2)
        {
            weaponholding = 1;
        }
    }

    public void noWeaponV()
    {

    }

    public void MP5V()
    {
        Instantiate(auto, transform.position, transform.rotation);
    }

    public void shotgunV()
    {
        Instantiate(shotgun, transform.position, transform.rotation);
    }

    public void pistolV()
    {
        Instantiate(single, transform.position, transform.rotation);
    }

    public void sniperV()
    {
        Instantiate(sniper, transform.position, transform.rotation);
    }

    public void burstV()
    {
        Instantiate(burst, transform.position, transform.rotation);
    }

    public void akimboV()
    {
        Instantiate(akimbo, transform.position, transform.rotation);
    }

    public void vectorV()
    {
        Instantiate(vector, transform.position, transform.rotation);
    }
}
