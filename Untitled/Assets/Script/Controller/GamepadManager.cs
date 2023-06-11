using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadManager : MonoBehaviour
{
    public Gamepad[] gamepadS;
    private void Start()
    {
        gamepadS = Gamepad.all.ToArray();

        Debug.Log(gamepadS.Length);
    }

    private void Update()
    {
        for (int i = 0; i < gamepadS.Length; i++)
        {
            Debug.Log(gamepadS[i]);
        }
    }
}

