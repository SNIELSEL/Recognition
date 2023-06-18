using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwap : MonoBehaviour
{
    public GameObject[] weapons;

    public void weapon1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
        }
            print("weapon1");
    }

    public void weapon2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            print("weapon2");
        }
    }

    public void weapon3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(false);
            print("weapon3");
        }
    }

    public void weapon4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(true);
            print("weapon4");
        }
    }
}
