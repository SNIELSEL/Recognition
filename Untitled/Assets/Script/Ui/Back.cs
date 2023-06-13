using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public PlayerControlls menuControlls;
    private InputAction back;

    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject startMenu;
    public Button selectButton;

    public void Awake()
    {
        menuControlls = new PlayerControlls();
    }
    public void Start()
    {
        back = menuControlls.MenuController.Back;
        back.Enable();
        back.performed += BackToMenu;

        void BackToMenu(InputAction.CallbackContext context)
        {
            settingsMenu.SetActive(false);
            creditsMenu.SetActive(false);
            startMenu.SetActive(true);
            selectButton.Select();
        }
    }
}
