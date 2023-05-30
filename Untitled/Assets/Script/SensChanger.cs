using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensChanger : MonoBehaviour
{
    public Slider sensSlider;

    public SaveAndLoad saveAndLoad;

    void Start()
    {
        LoadSens();

        if (saveAndLoad.sensitivity == 0)
        {
            saveAndLoad.sensitivity = 1;
            SaveSens();
            LoadSens();
        }
    }

    public void SensChange()
    {
        saveAndLoad.sensitivity = sensSlider.value;
        SaveSens();
    }

    public void LoadSens()
    {
        saveAndLoad.LoadData();
        sensSlider.value = saveAndLoad.sensitivity;
    }

    public void SaveSens()
    {
        saveAndLoad.SaveData();
    }
}
