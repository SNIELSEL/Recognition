using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverSelect : MonoBehaviour
{
    public void HoverSelect(Selectable selectable)
    {
        selectable.Select();
    }
}
