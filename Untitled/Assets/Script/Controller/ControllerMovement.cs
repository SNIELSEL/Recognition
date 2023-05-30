using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerMovement : MonoBehaviour
{
    public PlayerControlls playerControlls;


    public void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    public void OnEnable()
    {
        playerControlls.Enable();
    }

    public void OnDisable()
    {
            playerControlls.Disable();
    }


}
