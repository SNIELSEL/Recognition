using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathOrWinScript : MonoBehaviour
{
    [Header("Loading fade in")]
    public bool beganCountDown;
    public bool beginLoading;
    public bool endLoading;
    public Color[] fadeInColors;
    public float fadeInSpeed;
    public float fadeOutSpeed;
    public Image[] deathImages;

    [Header("Countdown Objects")]
    public GameObject returnMessageObjects;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI winOrLosstext;

    [Header("Scripts")]
    public SceneLoad sceneLoad;
    public mouseLock mouseLock;
    public SaveAndLoad saveAndLoad;
    public WaveSystem waveSystem;
    public PlayFabManager playFabManager;

    [Header("RandomStuff")]
    public int scenetoload;
    public AudioListener audioListener;

    public void Update()
    {
        deathImages[0].color = fadeInColors[0];
        deathImages[1].color = fadeInColors[1];
        deathImages[2].color = fadeInColors[1];

        if (deathImages[0].color.a < 1 && beginLoading)
        {
            fadeInColors[0].a += fadeInSpeed * Time.deltaTime;
        }
        else
        {
            if (endLoading == true)
            {
                fadeInColors[0].a -= fadeOutSpeed * Time.deltaTime;

            }
        }

        if (deathImages[1].color.a < 0.18f && beginLoading)
        {
            fadeInColors[1].a += fadeInSpeed * Time.deltaTime;
        }
        else
        {
            if (endLoading == true)
            {
                fadeInColors[1].a -= fadeOutSpeed * Time.deltaTime;

            }
        }
    }

    public void BeginCountdown()
    {
        if (!beganCountDown)
        {
            audioListener.enabled = false;
            beginLoading = true;
            beganCountDown = true;
            returnMessageObjects.SetActive(true);
            StartCoroutine(CountDown());
        }
    }

    public IEnumerator CountDown()
    {
        if(playFabManager.saveWaveForLeaderBoard)
        {
            playFabManager.SendLeaderBoard(waveSystem.waveRound);
        }
        countdownText.text = ("5");
        yield return new WaitForSeconds(1);
        countdownText.text = ("4");
        yield return new WaitForSeconds(1);
        countdownText.text = ("3");
        yield return new WaitForSeconds(1);
        countdownText.text = ("2");
        yield return new WaitForSeconds(1);
        countdownText.text = ("1");
        beginLoading = false;
        yield return new WaitForSeconds(1);

        fadeInColors[1].a -= 1;
        returnMessageObjects.SetActive(false);

        mouseLock.isLocked = false;
        sceneLoad.LoadGame(scenetoload);
    }
}
