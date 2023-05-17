using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LetterRandom : MonoBehaviour
{
    public char[] letters, tekens , random;

    public bool[] unlocked;

    public bool done;

    private void Start()
    {
        letters = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        tekens = new char[] {'!', '@', '~', '$', '#', '%', '^', '&', '*', '(', ')', '-', '=', '+', '|', '[', ']', '{', '}', ';', '<', '>', '/', '?', '"', '€'};

        LetterRandomV();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Start();
        }
    }

    void LetterRandomV()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            if (unlocked[i] == false)
            {
                random[i] = tekens[Random.Range(0, 25)];
            }

            else
            {
                random[i] = letters[i];
            }

            if (i == letters.Length) { 
            }

        }

        return;
    }
}
