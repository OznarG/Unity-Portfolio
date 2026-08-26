using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterController : MonoBehaviour
{
    FPSCharacterStats fpsStats;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector3 velocity;
    [SerializeField] bool isGrounded;
    private PlayerInput playerInput;
    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpsStats = GetComponent<FPSCharacterStats>();
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Moveplayer();
    }
    void OnJump()
    {
        Debug.Log("Jump Pressed");
        JumpingPlayer();
    }

    bool IsGrounded()
    {
        
        if (Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask))
        {
            fpsStats.is_Jumping = false;            
        }
        else
        {
            fpsStats.is_Jumping = true;
        }
        
        return isGrounded = Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask);
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Moveplayer()
    {
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y ;
        direction.Normalize();

        characterController.Move(direction * fpsStats.currentSpeed * Time.deltaTime);

        if (IsGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += fpsStats.gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
    void JumpingPlayer()
    {
        if (IsGrounded() && !fpsStats.is_Jumping)
        {
            Debug.Log("Inside JumpingPlayer");
            velocity.y = Mathf.Sqrt(fpsStats.jumpForce * -2 * fpsStats.gravity);
        }
    }
    void Loop()
    {

    }
}
