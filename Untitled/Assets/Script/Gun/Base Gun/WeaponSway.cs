using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    public float smooth, sway;

    private PlayerControlls input;

    private InputAction mouse;

    private void Awake()
    {
        input = new PlayerControlls();
    }

    private void OnEnable()
    {
        mouse = input.DeafultMovement.Rotation;
        mouse.Enable();
    }

    private void OnDisable()
    {
        mouse.Disable();
    }

    private void Update()
    {
        float x = mouse.ReadValue<Vector2>().x * sway;
        float y = mouse.ReadValue<Vector2>().y * sway;

        Quaternion rotationX = Quaternion.AngleAxis(-y, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(x, Vector3.up);

        Quaternion target= rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, smooth * Time.deltaTime);
    }
}
