using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterController : MonoBehaviour
{
    FPSCharacterStats fpsStats;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector3 velocity;
    private bool isGrounded;
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


    }

    bool CheckGround()
    {
        return Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask);
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Moveplayer()
    {
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y ;
        direction.Normalize();

        characterController.Move(direction * fpsStats.walkSpeed * Time.deltaTime);

        if (CheckGround() && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += fpsStats.gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void Loop()
    {

    }
}
