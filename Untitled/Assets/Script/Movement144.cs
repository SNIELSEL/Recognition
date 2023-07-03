using UnityEngine;
using UnityEngine.InputSystem;

public class Movement144 : MonoBehaviour
{
    public float movespeed, sens, jumpHight;
    private float moveLock, jumpVol;

    private PlayerControlls input;

    private InputAction move;
    private InputAction mouse;
    private InputAction jump;
    private InputAction sprint;

    private Vector3 moveV2;
    private Vector2 mouseV2;
    private Vector3 jumpV3;

    private GameObject cam;

    private bool grounded, sprinting;
    private RaycastHit ground;
    private Rigidbody rb;

    public SaveAndLoad saveAndLoad;

    public float x, y;

    public InGameMenuController menuController;
    public extra extraS;

    private CharacterController characterController;

    public class extra
    {
        public float zoom, aimsens;
    }
    private void Awake()
    {
        input = new PlayerControlls();
        saveAndLoad.LoadData();
    }

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
        extraS = new extra();
        characterController = GetComponent<CharacterController>();

        jumpV3.y = jumpHight;
        moveLock = movespeed;
        extraS.zoom = 1;
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


        int layerMask = 1 << 3;
        if (Physics.Raycast(transform.position, -transform.up, out ground, 1.5f, layerMask))
        {
            grounded = true;
        }

        else
        {
            jumpVol -= Time.deltaTime * 10;
            grounded = false;
        }
    }

    private void FixedUpdate()
    {
        Movement();    
    }

    public void Movement()
    {
        moveV2.x = move.ReadValue<Vector2>().x;
        moveV2.z = move.ReadValue<Vector2>().y;
        moveV2 = moveV2.normalized;

        //transform.Translate(moveV2 * Time.deltaTime * movespeed);
        //rb.MovePosition(mouseV2 * Time.deltaTime * movespeed);

        Vector3 inputDirection = transform.right * moveV2.x + transform.forward * moveV2.z;
        //Vector3 inputDirection = new Vector3(moveV2.x, 0.0f, moveV2.y).normalized;
        characterController.Move(inputDirection.normalized * (movespeed * Time.deltaTime) + new Vector3(0, jumpVol, 0) * Time.deltaTime);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (sprinting == true)
        {
            sprinting = false;
            movespeed = moveLock;
        }

        else if (sprinting == false)
        {
            sprinting = true;
            movespeed = moveLock * 1.5f;
        }
    }

    public void Rotation()
    {
        sens = saveAndLoad.sensitivity;

        mouseV2 = mouse.ReadValue<Vector2>() * (sens / extraS.zoom);

        y -= mouseV2.y;
        x += mouseV2.x;

        y = Mathf.Clamp(y, -85, 85);

        transform.localRotation = Quaternion.Euler(0, x, 0 * Time.deltaTime);
        cam.transform.localRotation = Quaternion.Euler(y, 0, 0 * Time.deltaTime);
    }

    public async void Jump(InputAction.CallbackContext context)
    {

        if (context.started && !menuController.inMenu && grounded == true)
        {
            jumpVol = Mathf.Sqrt(jumpHight);
        }
    }
}
