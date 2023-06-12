using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InGameMenuController : MonoBehaviour
{
    public GameObject uiObjects;
    public GameObject settingsMenu;
    public GameObject startMenu;
    public GameObject warningMenu;
    public Canvas gameUICanvas;
    public Button selectButton;

    public bool inMenu;

    public PlayerControlls menuControlls;
    private InputAction options;
    
    public mouseLock mouseLock;
    public Movement144 movement;

    public void Awake()
    {
        menuControlls = new PlayerControlls();
    }
    public void Start()
    {
        options = menuControlls.MenuController.OptionButton;
        options.Enable();
        options.performed += Options;
    }

    public void Options(InputAction.CallbackContext context)
    {
        if (!inMenu)
        {
            inMenu = true;
            Time.timeScale = 0;
            selectButton.Select();
            uiObjects.SetActive(true);
            movement.enabled = false;
            mouseLock.isLocked = false;
            gameUICanvas.gameObject.SetActive(false);
        }
        else
        {
            Continue();
        }
    }

    public void Continue()
    {
        inMenu = false;
        Time.timeScale = 1;
        uiObjects.SetActive(false);
        movement.enabled = true;
        mouseLock.isLocked = true;
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
        warningMenu.SetActive(false);
        gameUICanvas.gameObject.SetActive(true);
    }
}
