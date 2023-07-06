using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundPlayer : MonoBehaviour
{
    public AudioSource hitSound;

    public void Start()
    {
        StartCoroutine(HitObjectDeleter());
    }

    public IEnumerator HitObjectDeleter()
    {
        hitSound.Play();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
