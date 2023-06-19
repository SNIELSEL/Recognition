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
    private int spawnedEnemy, waveRound;
    public float wavemiltie;

    public GameObject[] inGameEnemy, spawnLoc;

    public float spawnSpeed;
    private float spawnTime;

    public GameObject[] enemy;

    public bool wave;

    public DeathOrWinScript deathOrWinScript;
    private TextMeshProUGUI text, wavetext;

    private bool Upgrade;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
        text = GameObject.Find("EnemiesAlive").GetComponent<TextMeshProUGUI>();
        wavetext = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>(); 

        leftEnemies = roundEnemy;
        wavemiltie = 1;
        waveRound = 1;

        wavetext.text = "Wave " + waveRound;
    }

    private void Update()
    {
        if(wave == true)
        {
            Spawn();
        }

        if (spawnedEnemy == roundEnemy)
        {
            if (inGameEnemy.Length == 0 && Upgrade == false)
            {
                Upgrade = true;
                GameObject.Find("Keep1").GetComponent<UpgradeUI>().click();
            }
        }

        text.text = leftEnemies.ToString() + " Enemies left";
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
    }

    public void NewWave()
    {
        spawnedEnemy = 0;
        roundEnemy += 3;
        waveRound += 1;

        //spawnSpeed /= 0.25f;
        wavemiltie += 0.125f;

        wavetext.text = "Wave " + waveRound;
        leftEnemies = roundEnemy;

        Upgrade = false;
    }
}
