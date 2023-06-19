using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    private GameObject ui, gameUI;
    private Movement144 move;

    private PlayerControlls input;
    private InputAction toggle;

    public Button upgradeSelected;

    private void Awake()
    {
        input = new PlayerControlls();
    }

    private void Start()
    {
        ui = GameObject.Find("Upgrade Field");
        gameUI = GameObject.Find("Canvas Game");
        move = GameObject.Find("Player").GetComponent<Movement144>();

        ui.SetActive(false);
    }

    private void OnEnable()
    {
        toggle = input.DeafultInput.Upgrade;
        toggle.Enable();
        toggle.started += Toggle;
    }

    private void OnDisable()
    {
        toggle.Disable();
    }

    public void Toggle(InputAction.CallbackContext context)
    {
            print("Upgrade");
        if (context.started)
        {

            if (ui.activeSelf == false)
            {
                ui.SetActive(true);
                gameUI.SetActive(false);
                move.enabled = false;
                GameObject.Find("Keep").GetComponent<mouseLock>().isLocked = false;
                GameObject.Find("Hand").GetComponentInChildren<Shoot>().enabled = false;
                GameObject.Find("Hand").GetComponentInChildren<BaseGun>().enabled = false;
                GameObject.Find("Hand").GetComponentInChildren<WeaponSway>().enabled = false;

                upgradeSelected.Select();
            }

            else
            {
                ui.SetActive(false);
                gameUI.SetActive(true);
                move.enabled = true;
                GameObject.Find("Keep").GetComponent<mouseLock>().isLocked = true;
                GameObject.Find("Hand").GetComponentInChildren<Shoot>().enabled = true;
                GameObject.Find("Hand").GetComponentInChildren<BaseGun>().enabled = true;
                GameObject.Find("Hand").GetComponentInChildren<WeaponSway>().enabled = true;
            }
        }
    }

    public void click()
    {
        if (ui.activeSelf == false)
        {
            ui.SetActive(true);
            gameUI.SetActive(false);
            move.enabled = false;
            GameObject.Find("Keep").GetComponent<mouseLock>().isLocked = false;
            GameObject.Find("Hand").GetComponentInChildren<Shoot>().enabled = false;
            GameObject.Find("Hand").GetComponentInChildren<BaseGun>().enabled = false;
            GameObject.Find("Hand").GetComponentInChildren<WeaponSway>().enabled = false;
            Time.timeScale = 0;

            upgradeSelected.Select();
        }

        else
        {
            ui.SetActive(false);
            gameUI.SetActive(true);
            move.enabled = true;
            GameObject.Find("Keep").GetComponent<mouseLock>().isLocked = true;
            GameObject.Find("Hand").GetComponentInChildren<Shoot>().enabled = true;
            GameObject.Find("Hand").GetComponentInChildren<BaseGun>().enabled = true;
            GameObject.Find("Hand").GetComponentInChildren<WeaponSway>().enabled = true;

            Time.timeScale = 1;
        }
    }
}
