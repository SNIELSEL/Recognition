using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CoontrollerID : MonoBehaviour
{
    public PlayerControlls playerControlls;
    private InputAction options;

    public GameObject player;
    public Camera playerCamera;

    private Gamepad gamePad;
    public TMP_Text addDevicetext;

    private Vector3 spawnPosition;
    
    private int deviceID; 
    private string textString;
    private float spawnRadius,newCamH,newCamY;
    private bool viewIsPressed;

    public void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    void Start()
    {

        Rect viewportRect = playerCamera.rect;
        viewportRect.height = newCamH;
        viewportRect.y = newCamY;

        spawnRadius = 10f;

        textString = ("Press view button to add controller");

        gamePad = Gamepad.current;

        if (gamePad != null)
        {
            deviceID = gamePad.deviceId;

            Debug.Log("Controller Device ID: " + deviceID);
        }

        else
        {
            Debug.LogError("Controller not found!");
        }
    }

    void Update()
    {
        CameraChange();
    }

    public void ViewPressed(InputAction.CallbackContext context)
    {
        if (context.control.device is Keyboard)
        {
            Debug.Log("keyboard");
        }
        else if (context.control.device is Gamepad)
        {
            Debug.Log("gamepad");
        }
        if (deviceID >= 3)
        {
            addDevicetext.text = textString;
        }

        if (context.performed && deviceID <= 5)
        {
            viewIsPressed = true;

            spawnPosition = Random.insideUnitSphere * spawnRadius;
            spawnPosition += transform.position;

            Instantiate(player, spawnPosition, Quaternion.identity);
        }
    }

    private void CameraChange()
    {
        if (deviceID >= 3 && viewIsPressed == true)
        {
            newCamH = .505f;
            newCamY = .5f;
        }
    }
}
