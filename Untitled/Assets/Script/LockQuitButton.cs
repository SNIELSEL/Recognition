using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LockQuitButton : MonoBehaviour
{
    public TextMeshProUGUI lockText;
    public Button quitButton;
    public bool lockedQuit;

    public PlayerControlls menuControlls;
    private InputAction lockQuit;

    public void Awake()
    {
        menuControlls = new PlayerControlls();
    }
    public void Start()
    {
        lockQuit = menuControlls.MenuController.LockQuit;
        lockQuit.Enable();
        lockQuit.performed += Lock;
    }

    public void Lock(InputAction.CallbackContext context)
    {
        if (!lockedQuit)
        {
            lockedQuit = true;
            quitButton.interactable = false;
            lockText.text = ("Locked");
        }
        else
        {
            lockedQuit = false;
            quitButton.interactable = true;
            lockText.text = ("Quit Game");
        }
    }
}
