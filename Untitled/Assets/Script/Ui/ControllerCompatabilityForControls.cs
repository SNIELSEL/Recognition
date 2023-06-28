using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCompatabilityForControls : MonoBehaviour
{
    public RectTransform rectTransform;

    public float scrollSpeed;
    // Update is called once per frame
    void Update()
    {

    }

    public void ContentChange()
    {
        if (gameObject.name == "DownButton")
        {
            rectTransform.anchoredPosition3D -= new Vector3(0, -scrollSpeed, 0);
        }

        if (gameObject.name == "UpButton")
        {
            rectTransform.anchoredPosition3D -= new Vector3(0, scrollSpeed, 0);
        }
    }
}
