using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class mouseLock : MonoBehaviour
{
    public bool isLocked;
    private PlayerControlls playerControlls;
    private InputAction action;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    public void OnEnable()
    {
        action = playerControlls.DeafultMovement.MouseLock;
        action.Enable();
        action.performed += Switch;
    }

    public void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isLocked = true;
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if (isLocked == false)
        {
            isLocked = true;
        }
        else
        {
            isLocked = false;
        }
    }

    private void Update()
    {
        if (isLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (isLocked == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
