using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WaveSystem : MonoBehaviour
{
    public int roundEnemy, leftEnemies, waveRound, lastWaveRound;
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

    private string currentSceneName;

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
        currentSceneName = SceneManager.GetActiveScene().name;

        saveAndLoad.LoadData();

        if(saveAndLoad.difficulty == 0)
        {
            difficulty = Difficulty.Easy;

            if (currentSceneName == "Mars")
            {
                playFabManager.currentLeaderboardToSendDataTo = 0;
            }
            else if (currentSceneName == "Snow")
            {
                playFabManager.currentLeaderboardToSendDataTo = 3;
            }
        }

        else if (saveAndLoad.difficulty == 1)
        {
            difficulty = Difficulty.Normal;

            if (currentSceneName == "Mars")
            {
                playFabManager.currentLeaderboardToSendDataTo = 1;
            }
            else if (currentSceneName == "Snow")
            {
                playFabManager.currentLeaderboardToSendDataTo = 4;
            }
        }

        else if (saveAndLoad.difficulty == 2)
        {
            difficulty = Difficulty.Hard;

            if(currentSceneName == "Mars")
            {
                playFabManager.currentLeaderboardToSendDataTo = 2;
            }
            else if(currentSceneName == "Snow")
            {
                playFabManager.currentLeaderboardToSendDataTo = 5;
            }
        }

        extra = new Extra();
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
        text = GameObject.Find("EnemiesAlive").GetComponent<TextMeshProUGUI>();
        wavetext = GameObject.Find("Wave").GetComponent<TextMeshProUGUI>(); 

        leftEnemies = roundEnemy;
        wavemiltie = 1;
        waveRound = 1;
        lastWaveRound = 0;
        saveAndLoad.waveRound = waveRound + 10;
        saveAndLoad.SaveWaveData();

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

        saveAndLoad.LoadWaveData();
        waveRound = saveAndLoad.waveRound - 10;


        StartCoroutine(SaveTheWaveData());

        //spawnSpeed /= 0.25f;
        wavemiltie += 0.125f * extra.diffMulti;

        leftEnemies = roundEnemy;

        Upgrade = false;
    }

    public IEnumerator SaveTheWaveData()
    {
        yield return new WaitForSeconds(0.2f);
        if(waveRound == lastWaveRound + 1)
        {
            waveRound += 1;
            lastWaveRound += 1;
            wavetext.text = "Wave " + waveRound;
            saveAndLoad.waveRound = waveRound + 10;
            saveAndLoad.SaveWaveData();
        }
        else
        {
            waveRound = lastWaveRound;
            waveRound += 1;

            wavetext.text = "Wave " + waveRound;
            saveAndLoad.waveRound = waveRound + 10;
            saveAndLoad.SaveWaveData();
        }
    }
}
