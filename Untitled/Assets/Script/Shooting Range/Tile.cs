using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject center;
    private Vector3 newLocation;

    public void Start()
    {
        center = GameObject.Find("Tiles");

        newLocation = new Vector3(0f, Random.Range(-5, 5), Random.Range(-10, 10));

        gameObject.transform.position = center.transform.position + newLocation;
    }

    public void Hit()
    {
        newLocation = new Vector3 (0f, Random.Range(-5, 5), Random.Range(-10, 10));

        gameObject.transform.position = center.transform.position + newLocation;
    }
}
