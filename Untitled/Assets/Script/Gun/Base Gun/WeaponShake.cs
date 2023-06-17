using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShake : MonoBehaviour
{
    public float shake, smooth;

    private Quaternion target, rotationX, rotationY;

    public void Shake()
    {
        rotationX = Quaternion.AngleAxis(shake, Vector3.right);
        rotationY = Quaternion.AngleAxis(shake, Vector3.up);

        target = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, smooth * Time.deltaTime);
    }
}
