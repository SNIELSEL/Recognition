using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudioPlayer : MonoBehaviour
{
    public AudioSource zombieAudio1;
    public AudioSource zombieAudio2;
    public AudioSource zombieAudio3;

    public int selectedaudio;
    public int delayTime;

    private bool firstSound;
    void Start()
    {
        firstSound = true;
        StartCoroutine(ZombieAudioPlayers());
    }

    public IEnumerator ZombieAudioPlayers()
    {
        if (firstSound)
        {
            delayTime = Random.Range(10, 20);
        }
        else
        {
            delayTime = Random.Range(30, 60);
        }
        yield return new WaitForSeconds(delayTime);
        selectedaudio = Random.Range(1,3);
        yield return new WaitForSeconds(0.5f);

        if (selectedaudio == 1)
        {
            zombieAudio1.Play();
        }
        else if (selectedaudio == 2)
        {
            zombieAudio2.Play();
        }
        else if (selectedaudio == 3)
        {
            zombieAudio3.Play();
        }

        StartCoroutine(ZombieAudioPlayers());
    }
}
