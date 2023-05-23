using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{

    public void FullscreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Changed Screen");
    }
}
