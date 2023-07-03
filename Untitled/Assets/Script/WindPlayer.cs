using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlayer : MonoBehaviour
{
    public AudioSource windStorm;

    public WalkAudio walkAudio;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            windStorm.Play();
            RenderSettings.fogDensity = 0.05f;
            walkAudio.inVoid = false;
            walkAudio.onMars = true;
        }
    }
}
