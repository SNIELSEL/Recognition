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

    public SaveAndLoad saveAndLoad;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }
    public void Start()
    {
        saveAndLoad.LoadData();

        if(saveAndLoad.difficulty == 0)
        {
            menu.text = ("Easy");
            difficulty = Difficulty.Easy;
        }

        else if(saveAndLoad.difficulty == 1)
        {
            menu.text = ("Normal");
            difficulty = Difficulty.Normal;
        }

        else if (saveAndLoad.difficulty == 2)
        {
            menu.text = ("Hard");
            difficulty = Difficulty.Hard;
        }
    }

    private void Update()
    {
        if (menu.text == Difficulty.Easy.ToString())
        {
            difficulty = Difficulty.Easy;
            saveAndLoad.difficulty = 0;
            saveAndLoad.SaveData();
        }

        else if (menu.text == Difficulty.Normal.ToString())
        {
            difficulty = Difficulty.Normal;
            saveAndLoad.difficulty = 1;
            saveAndLoad.SaveData();
        }

        else if (menu.text == Difficulty.Hard.ToString())
        {
            difficulty = Difficulty.Hard;
            saveAndLoad.difficulty = 2;
            saveAndLoad.SaveData();
        }
    }
}
