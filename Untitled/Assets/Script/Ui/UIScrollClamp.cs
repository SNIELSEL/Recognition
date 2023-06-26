using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollClamp : MonoBehaviour
{
    public RectTransform rectTransform;
    public float clampedValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rectTransform.position.y = clampedValue;
        clampedValue = Mathf.Clamp(clampedValue, -0, 0);
    }
}
