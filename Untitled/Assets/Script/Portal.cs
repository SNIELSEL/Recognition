using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject gamePlayer;

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        gamePlayer.transform.eulerAngles = Player.transform.eulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = gamePlayer.transform.position;
            other.gameObject.transform.rotation = gamePlayer.transform.rotation;
        }
    }
}
