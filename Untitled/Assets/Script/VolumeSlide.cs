using Coffee.UIExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VolumeSlide : MonoBehaviour
{
    public Slider volumeSlider;

    public UIParticle sliderParticle;
    public ParticleSystem[] particlesettings;

    private bool playingParticles;
    void Start()
    {
        sliderParticle.Stop();

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }

        else
        {
            LoadVolume();
        }
    }

    public void VolumeChanger()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }

    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void SpawnParticle()
    {
        if(!playingParticles)
        {
            playingParticles = true;
            sliderParticle.Play();
        }
    }

    public void EndParticle()
    {
        playingParticles = false;
        particlesettings[0].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        particlesettings[1].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        particlesettings[2].Stop(true, ParticleSystemStopBehavior.StopEmitting);
        particlesettings[3].Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
