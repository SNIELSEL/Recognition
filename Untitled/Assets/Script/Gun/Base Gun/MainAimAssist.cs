using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAimAssist : MonoBehaviour
{
    public float strength, radius, distence;

    private GameObject cam;
    private Movement144 movement;
    public Vector3 target;

    public Vector3 camera, enemy;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        movement = transform.GetComponent<Movement144>();
    }

    private void Update()
    {
        //AimAssist();
        First();
    }

    private void First()
    {
        RaycastHit hit, center;

        Physics.SphereCast(cam.transform.position, radius / 1.1f, cam.transform.forward, out center, distence);
        camera = cam.transform.eulerAngles;

        if (Physics.SphereCast(cam.transform.position, radius, cam.transform.forward, out hit, distence) && hit.transform.tag == "Enemy" && hit.transform == center.transform)
        {
            enemy = hit.transform.eulerAngles;
            print(target);
            target = ((hit.transform.eulerAngles - cam.transform.eulerAngles) * (strength / 1000)).normalized;

            if (target.y > (0.5 / strength) || target.y < (-0.5 / strength))
            {
                movement.y -= target.x;
            }

            if (target.z > (0.5 / strength) || target.z < (-0.5 / strength))
            {
                movement.x -= target.z;
            }

            movement.y -= target.x;
            movement.x -= target.x;
        }
                                                                            
        else
        {
            target = new Vector3(0, 0, 0);
        }
    }

    public void AimAssist()
    {
        RaycastHit hit, center;

        if (Physics.SphereCast(cam.transform.position, radius, cam.transform.forward, out center, distence) && center.transform.tag == "Enemy")
        {
            camera = cam.transform.eulerAngles;
            enemy = center.transform.eulerAngles; 

            target.x = camera.x / enemy.x;
            target.y = camera.y / enemy.y;
            target.z = camera.z / enemy.z;

            print(target);
        }
    }
}
