using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public Image hurtImage;
    public Color fadecolor;

    public void Start()
    {
        hurtImage = GameObject.Find("HurtImage").GetComponent<Image>();
        fadecolor.a = 0;
    }

    public void Update()
    {
        hurtImage.color = fadecolor;
    }
    public void IncreaseColor()
    {
        if (fadecolor.a < 1)
        {
            fadecolor.a += 0.01f * Time.deltaTime;
            IncreaseColor();
        }
        else
        {
            StartCoroutine(BloodTimer());
        }
    }
    public IEnumerator BloodTimer()
    {
        yield return new WaitForSeconds(4);
        fadecolor.a = 0;
    }
}
