using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseLock : MonoBehaviour
{
    public bool isLocked;
    public KeyCode lockButton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isLocked = true;
    }
    private void Update()
    {
        if (Input.GetKeyUp(lockButton))
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
