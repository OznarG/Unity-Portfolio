using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterController : MonoBehaviour
{
    FPSCharacterStats fpsStats;
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded;
    private PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpsStats = GetComponent<FPSCharacterStats>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
    }

    private void FixedUpdate()
    {
        Moveplayer();
    }
    void OnJump()
    {
        if(isGrounded)
        {
            rb.AddForce(new Vector3(0, fpsStats.jumpForce, 0), ForceMode.Impulse);
        }

    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask);
    }

    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Moveplayer()
    {
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y ;
        direction.Normalize();

        rb.linearVelocity = new Vector3(direction.x * fpsStats.speed, rb.linearVelocity.y, direction.z * fpsStats.speed);
    }

    void Loop()
    {

    }
}
