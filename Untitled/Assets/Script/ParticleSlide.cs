using Coffee.UIExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ParticleSlide : MonoBehaviour
{
    public Slider slider;

    public UIParticle sliderParticle;
    public ParticleSystem[] particlesettings;

    private bool playingParticles;

    void Start()
    {
        sliderParticle.Stop();
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
    }
}
