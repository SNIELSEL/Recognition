using UnityEngine;
using UnityEngine.InputSystem;

public class WalkAudio : MonoBehaviour
{
    public float movementSpeed = 5f;
    public AudioSource audioSource;
    public AudioClip voidWalkingSound;
    public AudioClip marsWalkingSound;

    public bool onMars;
    public bool inVoid;

    private PlayerControlls playerControls;
    private Vector2 movementInput;

    private void Awake()
    {
        inVoid = true;
        playerControls = new PlayerControlls();

        // Assign the movement input action
        playerControls.DeafultMovement.Movement.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        playerControls.DeafultMovement.Movement.canceled += ctx => movementInput = Vector2.zero;

        // Enable the player controls
        playerControls.DeafultMovement.Enable();
    }

    private void Update()
    {
        // Move the player based on input
        Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        transform.Translate(movement * movementSpeed * Time.deltaTime);

        // Play walking sound if the player is moving
        if (movement.magnitude > 0 && onMars)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = Random.Range(1f, 1.2f);
                audioSource.clip = marsWalkingSound;
                audioSource.Play();
            }
        }
        
        
        if (movement.magnitude > 0 && inVoid)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = 1;
                audioSource.clip = voidWalkingSound;
                audioSource.Play();
            }
        }

        if (movement.magnitude > 0)
        {

        }
        else
        {
            audioSource.Stop();
        }
    }

    private void OnDestroy()
    {
        // Disable the player controls
        playerControls.DeafultMovement.Disable();
    }
}
