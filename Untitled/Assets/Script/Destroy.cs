using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float delay;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (delay < timer)
        {
            Destroy(gameObject);
        }
    }
}
