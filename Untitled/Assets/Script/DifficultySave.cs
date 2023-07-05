using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DifficultySave : MonoBehaviour
{
    public TextMeshProUGUI menu;

    public Difficulty difficulty;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Update()
    {
        if (menu.text == Difficulty.Easy.ToString())
        {
            difficulty = Difficulty.Easy;
        }

        else if (menu.text == Difficulty.Normal.ToString())
        {
            difficulty = Difficulty.Normal;
        }

        else if (menu.text == Difficulty.Hard.ToString())
        {
            difficulty = Difficulty.Hard;
        }
    }
}
