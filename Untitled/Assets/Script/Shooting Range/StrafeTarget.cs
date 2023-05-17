using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrafeTarget : MonoBehaviour
{
    public float speed;
    public GameObject center, target;
    private Vector3 newLocation;

    public void Start()
    {
        center = GameObject.Find("strafe center");

        newLocation = new Vector3(Random.Range(-5, 5), 0, Random.Range(-10, 10));

        target.transform.position = center.transform.position + newLocation;

        gameObject.transform.LookAt(target.transform.position);
    }

    private void Update()
    {
        //transform.Translate(transform.forward * Time.deltaTime * speed);
    }

    public void Location()
    {
        newLocation = new Vector3(Random.Range(-5, 5), 0, Random.Range(-10, 10));

        target.transform.position = center.transform.position + newLocation;

        gameObject.transform.LookAt(target.transform.position);
    }
}
