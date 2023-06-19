using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Upgrade Upgrade;

    public int Stacks;
    private RawImage image;
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        image = gameObject.transform.Find("Icon").GetComponent<RawImage>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (Upgrade != null)
        {
            image.texture = Upgrade.image;

            if (Stacks > 1)
            {
                textMeshPro.text = Stacks.ToString();
            }

            else
            {
                textMeshPro.text = null;
            }
        }
    }
}
