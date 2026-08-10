using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterController : MonoBehaviour
{
    [SerializeField] FPSCharacterStats fpsStats;
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded;
    private PlayerInput playerInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpsStats = GetComponent<FPSCharacterStats>();
        rb = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
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
}
