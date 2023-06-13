using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathOrWinScript : MonoBehaviour
{
    public bool beganCountDown;

    public GameObject returnMessageObjects;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI winOrLosstext;

    public int scenetoload;

    public SceneLoad sceneLoad;
    public mouseLock mouseLock;

    public void BeginCountdown()
    {
        if (!beganCountDown)
        {
            beganCountDown = true;
            returnMessageObjects.SetActive(true);
            StartCoroutine(CountDown());
        }
    }

    public IEnumerator CountDown()
    {
        countdownText.text = ("5");
        yield return new WaitForSeconds(1);
        countdownText.text = ("4");
        yield return new WaitForSeconds(1);
        countdownText.text = ("3");
        yield return new WaitForSeconds(1);
        countdownText.text = ("2");
        yield return new WaitForSeconds(1);
        countdownText.text = ("1");
        yield return new WaitForSeconds(1);
        mouseLock.isLocked = false;
        sceneLoad.LoadGame(scenetoload);
    }
}
