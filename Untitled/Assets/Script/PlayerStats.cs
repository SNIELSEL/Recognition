using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float hp;

    private void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene(sceneName: "Brian Test Scene");
        }
    }
}
