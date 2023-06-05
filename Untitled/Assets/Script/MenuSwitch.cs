using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitch : MonoBehaviour
{
    public void EnableMenus(GameObject EnableMenu)
    {
        EnableMenu.SetActive(true);
    }

    public void DisableMenus(GameObject DisableMenu)
    {
        DisableMenu.SetActive(false);
    }
    public void SelectButton(Button buttonToSelect)
    {
        buttonToSelect.Select();
    }
}
