using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WaveSystem : MonoBehaviour
{
    public int roundEnemy, leftEnemies, waveRound;
    private int spawnedEnemy;
    public float wavemiltie;

    public GameObject[] inGameEnemy, spawnLoc;

    public float spawnSpeed;
    private float spawnTime;

    public GameObject[] enemy;

    public bool wave;

    public DeathOrWinScript deathOrWinScript;
    private TextMeshProUGUI text, wavetext;

    private bool Upgrade;

    public Difficulty difficulty;
    public Extra extra;
    public SaveAndLoad saveAndLoad;
    public PlayFabManager playFabManager;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public class Extra
    {
        public float diffMulti, diffSpeed;
    }

    private void Start()
    {
        saveAndLoad.LoadData();
        if(saveAndLoad.difficulty == 0)
        {
            difficulty = Difficulty.Easy;

            playFabManager.currentLeaderboardToSendDataTo = 0;
        }

        else if (saveAndLoad.difficulty == 1)
        {
            difficulty = Difficulty.Normal;

            playFabManager.currentLeaderboardToSendDataTo = 1;
        }

        else if (saveAndLoad.difficulty == 2)
        {
            difficulty = Difficulty.Hard;

            playFabManager.currentLeaderboardToSendDataTo = 2;
        }

        extra = new Extra();
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
        text = GameObject.Find("EnemiesAlive").GetComponent<TextMeshProUGUI>();
        wavetext = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>(); 

        leftEnemies = roundEnemy;
        wavemiltie = 1;
        waveRound = 1;

        wavetext.text = "Wave " + waveRound;

        if (difficulty == Difficulty.Easy)
        {
            extra.diffMulti = .5f;
            extra.diffSpeed = .7f;
        }

        else if (difficulty == Difficulty.Normal)
        {
            extra.diffMulti = 1;
            extra.diffSpeed = 1;
        }

        else if (difficulty == Difficulty.Hard)
        {
            extra.diffMulti = 2;
            extra.diffSpeed = 1.5f;
        }
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
        roundEnemy += 4;
        waveRound += 1;

        //spawnSpeed /= 0.25f;
        wavemiltie += 0.125f * extra.diffMulti;

        wavetext.text = "Wave " + waveRound;
        leftEnemies = roundEnemy;

        Upgrade = false;
    }
}
