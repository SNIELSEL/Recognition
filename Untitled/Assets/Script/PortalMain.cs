using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PortalMain : MonoBehaviour
{
    private GameObject[] player;
    private GameObject tpLocation;

    private WaveSystem wave;

    private void Start()
    {
        tpLocation = GameObject.Find("TeleportCamp");
        player = GameObject.FindGameObjectsWithTag("Player");
        wave = GameObject.Find("Spawners").GetComponent<WaveSystem>();
        wave.wave = false;
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
            //RenderSettings.fog = true;
            print("start");
            wave.wave = true;
        }
    }
}
