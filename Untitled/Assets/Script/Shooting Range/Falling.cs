using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private GameObject centerSpawn;

    private Vector3 spawnPosition;

    public void Start()
    {
        centerSpawn = GameObject.Find("Falling Targets");

        spawnPosition = new Vector3(0f, 0f, Random.Range(-10, 10));

        gameObject.transform.position = centerSpawn.transform.position + spawnPosition;
    }

    public void Hit()
    {
        spawnPosition = new Vector3(0f, 0f, Random.Range(-10, 10));

        gameObject.transform.position = centerSpawn.transform.position + spawnPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground")
        {
            Hit();
        }
    }
}
