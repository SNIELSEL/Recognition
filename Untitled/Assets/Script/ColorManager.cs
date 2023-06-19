using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public Image hurtImage;
    public Color fadecolor;

    private Image hud;

    public void Start()
    {
        hurtImage = GameObject.Find("HurtImage").GetComponent<Image>();
        hud = GameObject.Find("HUD").GetComponent<Image>();
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
            hud.color = Color.red;
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
        //hud.color = new Color(0, 200, 300);
        hud.color = Color.cyan;
    }
}
