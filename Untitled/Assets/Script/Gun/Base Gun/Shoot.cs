using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool sniper;

    public KeyCode reload;

    private Movement Player;

    private GameObject test;

    public FireMode fireMode;

    public enum FireMode
    {
        single,
        burst,
        auto,
        akimbo
    }

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && fireMode == FireMode.auto)
        {
            GetComponent<BaseGun>().Shoot();
        }

        if (Input.GetMouseButtonDown(0) && fireMode == FireMode.single)
        {
            GetComponent<BaseGun>().Shoot();
        }

        if (Input.GetMouseButtonDown(0) && fireMode == FireMode.burst)
        {
            GetComponent<BaseGun>().Shoot();
        }

        if (Input.GetMouseButtonDown(1) && fireMode == FireMode.akimbo)
        {
            GetComponent<BaseGun>().Shoot();
        }



        if (Input.GetMouseButton(1) && fireMode != FireMode.akimbo)
        {
            GetComponent<BaseGun>().ADS();
        }

        else
        {
            GetComponent<BaseGun>().Normal();
        }

        if (Input.GetKeyDown(reload))
        {
            GetComponent<BaseGun>().Reload();
        }
    }
}
