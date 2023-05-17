using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //Keybind
    public KeyCode sprint, jump, croush;
    public KeyCode spect;

    //Movement
    public float movespeed;
    private float hor, vert;
    private Vector3 MoveV3;
    private RaycastHit face;
    private GameObject block;

    //Rotation
    public float sens;
    private float mousex, mousey;
    private Vector3 MouseV3;
    public GameObject cam;

    //Sprint   
    private float speedlock;

    //Jump
    public float jumphight;
    private bool grounded;
    private RaycastHit ground;
    private Rigidbody rb;
    private Vector3 JumpV3;

    //Spectaiter
    public bool spectate;

    private void Start()
    {
        speedlock = movespeed;
        JumpV3.y = jumphight;
        MouseV3.z = 0;

        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
        block = GameObject.Find("Block");
    }

    private void Update()
    {
        Rotation();
        Sprint();
        movement();


        if (spectate == true)
        {
            Spectate();

            if (Input.GetKeyDown(spect))
            {
                spectate = false;
            }
        }

        else
        {
            rb.useGravity = true;
            Jump();

            if (Input.GetKeyDown(spect))
            {
                spectate = true;
            }
        }
    }

    private void movement()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");

        if (grounded)
        {
            MoveV3.x = hor;
        }

        //MoveBlock();

        Debug.DrawRay(transform.position, transform.forward * 1.01f, Color.green);

        MoveV3.z = vert;

        transform.Translate(MoveV3* Time.deltaTime * movespeed);
    }

    public void MoveBlock()
    {
        Debug.DrawRay(block.transform.position, transform.forward * .5f, Color.magenta);
        Debug.DrawRay(block.transform.position, -transform.forward * .5f, Color.magenta);
        Debug.DrawRay(block.transform.position, transform.right * .5f, Color.magenta);
        Debug.DrawRay(block.transform.position, -transform.right * .5f, Color.magenta);

        if (Physics.Raycast(block.transform.position, transform.forward, out face, .5f) && face.transform.tag != "weapon")
        {
            print("BlockVert1");
            if (vert > 0)
            {
                vert = 0;
            }
        }

        if (Physics.Raycast(block.transform.position, -transform.forward, out face, .5f) && face.transform.tag != "weapon")
        {
            print("BlockVert2");
            if (vert < 0)
            {
                vert = 0;
            }
        }

        if (Physics.Raycast(block.transform.position, transform.right, out face, .5f) && face.transform.tag != "weapon")
        {
            print("BlockHor1");
            if (hor < 0)
            {
                hor = 0;
            }
        }

        if (Physics.Raycast(block.transform.position, -transform.right, out face, .5f) && face.transform.tag != "weapon")
        {
            print("BlockHor2");
            if (hor > 0)
            {
                hor = 0;
            }
        }
    }

    private void Rotation()
    {
        mousex = Input.GetAxis("Mouse X") * sens;
        mousey = Input.GetAxis("Mouse Y") * sens;

        MouseV3.x = mousex;
        MouseV3.y = mousey;

        cam.transform.Rotate(-MouseV3.y, 0, 0 * Time.deltaTime);
        transform.Rotate(0, MouseV3.x, 0 * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKey(sprint))
        {
            movespeed = speedlock * 1.5f;
        }

        else
        {
            movespeed = speedlock;
        }
    }

    private void Jump()
    {
        Debug.DrawRay(transform.position, -transform.up * 1.01f, Color.blue);
        int layerMask = 1 << 3;

        if (Physics.Raycast(transform.position, -transform.up, out ground , 2 , layerMask))
        {
            grounded = true;

            if (Input.GetKeyDown(jump))
            {
                rb.AddForce(JumpV3 * jumphight, ForceMode.Impulse);
            }
        }

        else
        {
            grounded = false;
        }
    }

    private void Spectate()
    {
        rb.useGravity = false;

        if (Input.GetKey(jump))
        {
            MoveV3.y = 1;
        }

        else if (Input.GetKey(croush))
        {
            MoveV3.y = -1;
        }

        else
        {
            MoveV3.y = 0;
        }
    }
}
