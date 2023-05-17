using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRandom : MonoBehaviour
{
    public string text;

    public char[] chats;

    private TextMeshProUGUI textMeshPro;

    private LetterRandom letters;

    private void Start()
    {
        letters = GameObject.Find("Keep").GetComponent<LetterRandom>();
        textMeshPro = GetComponent<TextMeshProUGUI>();

        TextRandoms();
    }

    private void Update()
    {
            if (letters.done == true)
        {
            TextRandoms();
        }
    }
    
    void TextRandoms()
    {
        chats = text.ToCharArray();

        for (int i = 0; i < chats.Length; i++)
        {
            for (int j = 0; j < letters.letters.Length; j++)
            {

                if (chats[i] == letters.letters[j])
                {
                    chats[i] = letters.random[j];
                }
            }
        }
        textMeshPro.text = new string(chats);
        return;
    }
}
