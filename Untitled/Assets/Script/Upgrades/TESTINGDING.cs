using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TESTINGDING : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => Lala("LALALALALALA"));
    }

    // Update is called once per frame
    void Lala(string test)
    {
        print(test);
    }
}
