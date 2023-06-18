using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float hp;

    public DeathOrWinScript deathOrWinScript;
    private TextMeshProUGUI text;

    public bool isDead;

    private void Start()
    {
        text = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = ((int)(hp)).ToString();
        if (hp <= 0)
        {
            hp = 0;

            isDead = true;
            deathOrWinScript.winOrLosstext.text = ("You Died");
            deathOrWinScript.BeginCountdown();
        }
    }
}
