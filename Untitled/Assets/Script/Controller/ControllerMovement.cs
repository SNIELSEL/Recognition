using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerMovement : MonoBehaviour
{
    public ControllerInput _controllerInput;
    private InputAction movement;

    private void Awake()
    {
        _controllerInput = new ControllerInput();
    }

    private void OnEnable()
    {
        movement = _controllerInput.Default.Movement;
        movement.Enable();
    }

    private Vector2 Movement ()
    {
        return movement.ReadValue<Vector2>();
    }

    private void Update()
    {
        Debug.Log(Movement());
    }

    public void Jump ()
    {
        Debug.Log("JUMP!");

    }
}
