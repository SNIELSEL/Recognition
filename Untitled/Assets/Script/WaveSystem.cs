using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WaveSystem : MonoBehaviour
{
    public int roundEnemy;
    public int spawnedEnemy;

    public GameObject[] inGameEnemy, spawnLoc;

    public float spawnSpeed;
    private float spawnTime;

    public GameObject[] enemy;

    public bool wave;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
    }

    private void Update()
    {
        if(wave == true)
        {
            Spawn();
        }

        if (spawnedEnemy > roundEnemy)
        {
            if (inGameEnemy.Length == 0)
            {
                SceneManager.LoadScene(sceneBuildIndex: 0);
            }
        }
    }

    public void Spawn()
    {
        spawnTime += Time.deltaTime;
        inGameEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (spawnTime >= spawnSpeed && spawnedEnemy <= roundEnemy)
        {
            spawnTime = 0;
            spawnedEnemy += 1;

            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnLoc[Random.Range(0, spawnLoc.Length)].transform.position, spawnLoc[Random.Range(0, spawnLoc.Length)].transform.rotation);
        }

        if (spawnedEnemy >= roundEnemy && inGameEnemy == null)
        {
            print("newWave");
        }
    }
}
