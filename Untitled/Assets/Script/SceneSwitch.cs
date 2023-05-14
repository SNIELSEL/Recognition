using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int activScene, maxScene;

    public void Start()
    {
        activScene = SceneManager.GetActiveScene().buildIndex;
        maxScene = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneSwitchV();
        }
    }

    public void SceneSwitchV()
    {
        if (activScene == maxScene)
        {
            SceneManager.LoadScene(sceneBuildIndex: activScene += 1);
        }

        else
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
