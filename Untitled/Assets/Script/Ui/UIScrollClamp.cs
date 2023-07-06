using sc.terrain.proceduralpainter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollClamp : MonoBehaviour
{
    public RectTransform rectTransform;
    public float clampedValue;
    public float left;
    public float right;
    private float startvalue;
    public Vector2 positionCheck;

    public void Start()
    {
        startvalue = clampedValue;
        rectTransform = this.GetComponent<RectTransform>();
    }
    public void Update()
    {
        positionCheck = rectTransform.anchoredPosition;

        if(positionCheck.y < 0)
        {
            clampedValue = 0;
            rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
            rectTransform.offsetMax = new Vector2(-right, rectTransform.offsetMax.y);
        }
        else
        {
            clampedValue = startvalue;
        }

        rectTransform.anchoredPosition3D = Vector3.ClampMagnitude(rectTransform.anchoredPosition3D, clampedValue);
    }
}
