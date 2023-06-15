using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public GameObject lastSelectedUI;
    public InputAction buttonPress;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSelectedUI != EventSystem.current.currentSelectedGameObject && EventSystem.current.currentSelectedGameObject != null)
        {
            lastSelectedUI = EventSystem.current.currentSelectedGameObject;
        }

        if(EventSystem.current.currentSelectedGameObject == null)
        {

            if (lastSelectedUI.GetComponent<Selectable>() != null)
            {
                lastSelectedUI.GetComponent<Selectable>().Select();
            }
        }

        if(lastSelectedUI == null)
        {

        }

    }
}
