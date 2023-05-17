using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPScounter : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    private void Start()
    {
        fpsText= GetComponent<TextMeshProUGUI>();
        StartCoroutine(FpsRefresh());
    }

    private void Update()
    {
       
    }

    IEnumerator FpsRefresh()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps);

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(FpsRefresh());
    }
}
