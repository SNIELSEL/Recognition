using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement144 : MonoBehaviour
{
    public float moveFactor, sens, jumpHight;
    private float sprintFactor = 1f;
    private float maxSprintFactor = 1.5f;

    private PlayerControlls input;

    private InputAction move;
    private InputAction mouse;
    private InputAction jump;
    private InputAction sprint;

    private Vector3 moveV3;
    private Vector2 mouseV2;
    private Vector3 jumpV3;

    private GameObject cam;


    private bool grounded, sprinting;
    private RaycastHit ground;
    private Rigidbody rb;

    private void Awake()
    {
        input = new PlayerControlls();
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();

        jumpV3.y = jumpHight;
    }

    private void OnEnable()
    {
        move = input.DeafultMovement.Movement;
        move.Enable();

        mouse = input.DeafultMovement.Rotation;
        mouse.Enable();

        jump = input.DeafultMovement.Jump;
        jump.Enable();
        jump.performed += Jump;

        sprint = input.DeafultMovement.Sprint;
        sprint.Enable();
        sprint.performed += Sprint;
    }

    private void OnDisable()
    {
        move.Disable();
        mouse.Disable();
        jump.Disable();
        sprint.Disable();
    }

    private void Update()
    {
        Rotation();
    }

    private void FixedUpdate()
    {
        Movement();    
    }

    public void Movement()
    {
        moveV3 = new Vector3(move.ReadValue<Vector2>().x, 0f, move.ReadValue<Vector2>().y);
        rb.AddRelativeForce((moveV3 * moveFactor) * Time.deltaTime, ForceMode.Acceleration);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (sprinting == true)
            {
                sprintFactor = 1f;
                sprinting = false;
            }

            else if (sprinting == false)
            {
                sprintFactor = maxSprintFactor;
                sprinting = true;
            }
        }
    }

    public void Rotation()
    {
        mouseV2 = mouse.ReadValue<Vector2>() * sens;

        cam.transform.Rotate(-mouseV2.y, 0, 0 * Time.deltaTime);
        transform.Rotate(0, mouseV2.x, 0 * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        int layerMask = 1 << 3;

        if (Physics.Raycast(transform.position, -transform.up, out ground, 2, layerMask))
        {
            rb.AddForce(jumpV3 * jumpHight, ForceMode.Impulse);
        }
    }
}
