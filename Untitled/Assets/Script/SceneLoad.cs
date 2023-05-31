using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public float transitionDelay;

    public SaveAndLoad saveAndLoad;

    public Canvas loadCanvas;
    public Image loadingScreen;

    public float deleteDelay;
    public float fadeInSpeed;
    public float fadeOutSpeed;
    private float loadingDelay;
    public float loadingDelayMultiplier;
    public Color loadingColor;
    public bool beginLoading;
    public bool endLoading;
    private int levelLoadInt;

    public GameObject loadingGameObjects;
    public Slider progressSlider;
    public TextMeshProUGUI loadingText;

    public void Start()
    {
        DontDestroyOnLoad(this);
        loadingDelay = 50 * Time.deltaTime * loadingDelayMultiplier;
    }
    public void LoadGame(int levelToLoadExisting)
    {
        levelLoadInt = levelToLoadExisting;
        StartCoroutine(LoadAndSceneCO());
    }

    public void NewGame(int levelToLoadNew)
    {
        levelLoadInt = levelToLoadNew;
        print("test");
        StartCoroutine(ContinueAndSceneCO());
    }

    public void Update()
    {
        loadingScreen.color = loadingColor;

        if (loadingScreen.color.a < 1 && beginLoading)
        {
            loadingColor.a += fadeInSpeed * Time.deltaTime;
        }
        else
        {
            if (endLoading == true)
            {
                loadingColor.a -= fadeOutSpeed * Time.deltaTime;

            }
        }
    }


    IEnumerator LoadSceneAsync()
    {
        loadingGameObjects.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(levelLoadInt);
        
        op.allowSceneActivation = false;
        yield return new WaitForSeconds(2);
        op.allowSceneActivation = true;

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            progressSlider.value = progress;
            loadingText.text = progress * 100f + "%";

            yield return null;
        }
        yield return new WaitForSeconds(3);
        loadingGameObjects.SetActive(false);
        beginLoading = false;
        endLoading = true;
        yield return new WaitForSeconds(deleteDelay);
        Destroy(gameObject);
    }
    public IEnumerator ContinueAndSceneCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        StartCoroutine(LoadSceneAsync());
        yield return new WaitForSeconds(transitionDelay);
    }
    public IEnumerator LoadAndSceneCO()
    {
        beginLoading = true;

        yield return new WaitForSeconds(loadingDelay);
        StartCoroutine(LoadSceneAsync());
        yield return new WaitForSeconds(transitionDelay);
    }
     
}

