using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSaver : MonoBehaviour
{
    public Slider slider;

    public SaveAndLoad saveAndLoad;

    void Start()
    {
        LoadSliderData();

        if (saveAndLoad.sensitivity == 0)
        {
            saveAndLoad.sensitivity = 1;
            SaveSliderData();
            LoadSliderData();
        }
    }

    public void ChangeSliderData()
    {
        saveAndLoad.sensitivity = slider.value;
        SaveSliderData();
    }

    public void LoadSliderData()
    {
        saveAndLoad.LoadData();
        slider.value = saveAndLoad.sensitivity;
    }

    public void SaveSliderData()
    {
        saveAndLoad.SaveData();
    }
}
