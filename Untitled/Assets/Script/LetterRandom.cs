using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LetterRandom : MonoBehaviour
{
    public char[] letters, numbers, tekens , randomL, randomN;

    public bool[] unlockedL, unlockedN;

    public bool done;

    private void Start()
    {
        letters = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        tekens = new char[] {'!', '@', '~', '$', '#', '%', '^', '&', '*', '(', ')', '-', '=', '+', '|', '[', ']', '{', '}', ';', '<', '>', '/', '?', '"', '€'};

        //NumberRandomV();
        LetterRandomV();
    }

    private void Update()
    {
        /* 
        if (Input.GetKeyDown(KeyCode.M))
        {
            Start();
        }
        */
    }

    void LetterRandomV()
    {
        for (int i = 0; i < letters.Length ; i++)
        {
            if (unlockedL[i] == false)
            {
                randomL[i] = tekens[Random.Range(0, 25)];
            }

            else
            {
                randomL[i] = letters[i];
            }

            if (i == letters.Length) 
            {
                NumberRandomV();
                print("LetterDone");
            }

        }

        return;
    }

    void NumberRandomV()
    {
        for (int K = 0; K < numbers.Length; K++)
        {
            print("numbers");

            if (unlockedN[K] == false)
            {
                randomN[K] = tekens[Random.Range(0, 25)];
            }

            else
            {
                randomN[K] = letters[K];
            }

            if (K == letters.Length)
            {
                done = true;
            }

        }

        return;
    }
}
