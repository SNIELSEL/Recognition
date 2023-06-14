using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WaveSystem : MonoBehaviour
{
    public int roundEnemy, leftEnemies;
    public int spawnedEnemy;

    public GameObject[] inGameEnemy, spawnLoc;

    public float spawnSpeed;
    private float spawnTime;

    public GameObject[] enemy;

    public bool wave;

    public DeathOrWinScript deathOrWinScript;
    private TextMeshProUGUI text;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
        text = GameObject.Find("EnemiesAlive").GetComponent<TextMeshProUGUI>();

        leftEnemies = roundEnemy;
    }

    private void Update()
    {
        if(wave == true)
        {
            Spawn();
        }

        if (spawnedEnemy == roundEnemy)
        {
            if (inGameEnemy.Length == 0)
            {
                deathOrWinScript.winOrLosstext.text = ("You killed all the enemies");
                deathOrWinScript.BeginCountdown();
            }
        }

        text.text = leftEnemies.ToString() + "left";
    }

    public void Spawn()
    {
        spawnTime += Time.deltaTime;
        inGameEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (spawnTime >= spawnSpeed && spawnedEnemy < roundEnemy)
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
