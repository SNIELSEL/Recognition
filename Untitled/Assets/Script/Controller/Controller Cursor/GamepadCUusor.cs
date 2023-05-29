using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class GamepadCUusor : MonoBehaviour
{
    [SerializeField]

    private PlayerInput playerInput;
    private Mouse virtualMouse;

    private void OnEnable()
    {
        if (virtualMouse != null)
        {
            virtualMouse = (Mouse) InputSystem.AddDevice("virtualMouse");
        }

        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);

            InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

            InputSystem.onAfterUpdate += UpdateMotion;
        }

    }

    private void UpdateMotion()
    {
        
    }

}
