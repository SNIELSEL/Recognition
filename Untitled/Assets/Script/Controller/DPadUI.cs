using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DPadUI : MonoBehaviour
{
    private PlayerControlls playerControlls;

    private InputAction dPadUp;
    private InputAction dPadDown;
    private InputAction dPadLeft;
    private InputAction dPadRight;
    private InputAction aButton;

    public int buttonSelect;
    public Button[] buttonArray;

    public void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    public void Start()
    {
        dPadDown = playerControlls.DeafultInput.down;
        dPadUp = playerControlls.DeafultInput.up;
        //dPadRight = playerControlls.DeafultInput.UI;
        //dPadLeft = playerControlls.DeafultInput.UI;
        //aButton = playerControlls.DeafultInput.UI;

        dPadDown.Enable();
        dPadUp.Enable();
        //dPadLeft.Enable();
        //dPadRight.Enable();
        //aButton.Enable();

       // buttonArray[buttonSelect].onClick.Equals(true);
    }

    public void Update()
    {

    }

    public void DPadDown (InputAction.CallbackContext context)
    {
        if (context.performed && buttonSelect >= 0 && buttonSelect <= buttonArray.Length -2)
        {
            buttonSelect += 1;
        }
    }

    public void DPadUp(InputAction.CallbackContext context)
    {
        if (context.performed && buttonSelect >= 1 && buttonSelect <= buttonArray.Length -1)
        {
            buttonSelect -= 1;
        }
    }
}
