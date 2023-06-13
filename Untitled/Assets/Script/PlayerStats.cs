using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float hp;

    public DeathOrWinScript deathOrWinScript;

    public bool isDead;
    private void Update()
    {
        if (hp <= 0)
        {
            isDead = true;
            deathOrWinScript.winOrLosstext.text = ("You Died");
            deathOrWinScript.BeginCountdown();
        }
    }
}
