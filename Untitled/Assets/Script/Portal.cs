using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject gamePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = gamePlayer.transform.position;
            other.gameObject.transform.rotation = gamePlayer.transform.rotation;
        }
    }
}
