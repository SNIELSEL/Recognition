using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRandom : MonoBehaviour
{
    private float number;

    public char[] letters, tekens , random;

    public bool[] unlocked;

    public string text;

    public char[] chats;

    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        //char[] letters = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};


        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        LetterRandom();
        TextRandoms();

        textMeshPro.text = new string(chats);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Start();
        }
    }

    void LetterRandom()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (unlocked[i] == false)
            {
                random[i] = tekens[Random.Range(0, 25)];
                //letters[i] = tekens[Random.Range(0, 25)];
            }

            else
            {
                random[i] = letters[i];
            }

        }

        return;
    }

    void TextRandoms()
    {
        chats = text.ToCharArray();

        for (int i = 0; i < chats.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {

                if (chats[i] == letters[j])
                {
                    chats[i] = random[j];
                }
            }
        }

        return;
    }
}
