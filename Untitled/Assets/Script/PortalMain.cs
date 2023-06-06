using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMain : MonoBehaviour
{
    private GameObject[] player;
    private GameObject tpLocation;

    private void Start()
    {
        tpLocation = GameObject.Find("TeleportCamp");

        player = GameObject.FindGameObjectsWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        Teleport();
    }

    public void Teleport()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].transform.position = tpLocation.transform.position;
            //player[i].transform.rotation = tpLocation.transform.rotation;
        }
    }
}
