using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public KeyCode pickupKey, dropkey;

    private Shoot gunScript;
    private BoxCollider coll;
    private Rigidbody rb;
    private GameObject player, gunPlace1, gunPlace2;
    private Camera cam;

    private float range;
    private float distance;
    private float mousescroll;

    private bool equipped;
    public static bool weaponSlot1, weaponSlot2;

    private GameObject gun;

    private GameObject pickuptext;


    private void Start()
    {
        gun = gameObject;
        gunScript = gameObject.GetComponent<Shoot>();
        coll = gameObject.GetComponent<BoxCollider>();
        cam = Camera.main;
        player = GameObject.Find("player");
        gunPlace1 = GameObject.Find("slot1");
        gunPlace2 = GameObject.Find("slot2");
        pickuptext = GameObject.Find("canvas Text");
        range = 5;
        rb = GetComponent<Rigidbody>();

        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            gunScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            weaponSlot1 = true;
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(gun.transform.position, player.transform.position);

        if(Input.GetKeyDown(dropkey) && equipped)
        {
            drop();
        }

        if (equipped)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

    public void pickup()
    {
        if (!weaponSlot1 || !weaponSlot2 && !equipped && distance <= range)
        {
            if(gunPlace1.activeSelf && weaponSlot1 == false)
            {
                equipped = true;
                weaponSlot1 = true;

                rb.isKinematic = true;
                coll.isTrigger = true;

                gunScript.enabled = true;

                transform.SetParent(gunPlace1.transform);
                transform.localScale = Vector3.zero;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                transform.localScale = Vector3.one;
            }

            if(gunPlace2.activeSelf && weaponSlot2 == false)
            {
                equipped = true;
                weaponSlot2 = true;

                rb.isKinematic = true;
                coll.isTrigger = true;

                gunScript.enabled = true;

                transform.SetParent(gunPlace2.transform);
                transform.localScale = Vector3.zero;
                transform.localRotation = Quaternion.Euler(Vector3.zero);
                transform.localScale = Vector3.one;
            }
        }
    }

    private void drop()
    {
        if (gunPlace1.activeSelf)
        {
            equipped = false;
            weaponSlot1 = false;

            rb.isKinematic = false;
            coll.isTrigger = false;

            gunScript.enabled = false;

            transform.SetParent(null);

            rb.velocity = player.GetComponent<Rigidbody>().velocity;
        }

        if (gunPlace2.activeSelf)
        {
            equipped = false;
            weaponSlot2 = false;

            rb.isKinematic = false;
            coll.isTrigger = false;

            gunScript.enabled = false;

            transform.SetParent(null);

            rb.velocity = player.GetComponent<Rigidbody>().velocity;
        }
    }
}
