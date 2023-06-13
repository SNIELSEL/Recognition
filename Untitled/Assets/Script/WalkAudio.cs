using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Coffee.UIExtensions.UIParticleAttractor;

public class WalkAudio : MonoBehaviour
{
    public PlayerControlls menuControlls;
    private InputAction walk;

    public AudioSource walkSound;
    public bool walkSoundPlaying;
    public void Awake()
    {
        menuControlls = new PlayerControlls();
    }
    public void Start()
    {
        walk = menuControlls.DeafultMovement.Movement;
        walk.Enable();
        walk.performed += Walk;
        walk.canceled += CancelAudio;
    }
    public void Walk(InputAction.CallbackContext context)
    {
        if (!walkSoundPlaying)
        {
            walkSoundPlaying = true;
            walkSound.Play();
        }
        else
        {

        }
    }

    public void CancelAudio(InputAction.CallbackContext context)
    {
        walkSound.Stop();
        walkSoundPlaying = false;
    }
}
