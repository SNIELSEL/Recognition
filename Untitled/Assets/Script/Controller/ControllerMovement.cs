using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerMovement : MonoBehaviour
{
    public ControllerInput _controllerInput;
    private InputAction movement, rotation, jump;

    private void Awake()
    {
        _controllerInput = new ControllerInput();
    }

    private void OnEnable()
    {
        movement = _controllerInput.Default.PlayerMovement;
        movement.Enable();

        rotation = _controllerInput.Default.Rotation;
        rotation.Enable();

        jump = _controllerInput.Default.Jump;
        jump.Enable();
    }

    private Vector2 Movement ()
    {
        return movement.ReadValue<Vector2>();
    }

    private Vector2 Rotation()
    {
        return rotation.ReadValue<Vector2>();
    }

    private void Update()
    {
        Debug.Log(Movement());
        //Debug.Log(Rotation());
    }

    public void Jump ()
    {
        Debug.Log("JUMP!");
    }
}
