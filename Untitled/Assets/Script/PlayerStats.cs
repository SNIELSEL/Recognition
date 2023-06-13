using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float hp;

    public DeathOrWinScript deathOrWinScript;
    private void Update()
    {
        if (hp <= 0)
        {
            deathOrWinScript.winOrLosstext.text = ("You Died");
            deathOrWinScript.BeginCountdown();
        }
    }
}
