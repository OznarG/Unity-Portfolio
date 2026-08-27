using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterController : MonoBehaviour
{
    //Components and References
    public Animator Animator;
    FPSCharacterStats fpsStats;
    private PlayerInput playerInput;
    private CharacterController characterController;
    //velocity and speed variables
    private Vector2 moveInput;
    private Vector3 velocity;
    //Condition Checkers 
    [SerializeField] bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get the components automatically
        fpsStats = GetComponent<FPSCharacterStats>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Moveplayer();
    }


    bool IsGrounded()
    {
        //Create a sphere on the given location of the given size and check if is hitting the ground layer or not
        //choose based on what is given then return 
        fpsStats.is_Jumping = Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask) ? false : true;
        return isGrounded = Physics.CheckSphere(fpsStats.groundCheck.position, fpsStats.groundDistance, fpsStats.groundMask);
    }
    void Moveplayer()
    {
        //Get the Speed where the player needs to get to based on running boolean
        float targetSpeed = fpsStats.is_Running ? fpsStats.runningSpeed : fpsStats.walkSpeed;
        //Lerp fast to slowly get to the desired speed
        fpsStats.currentSpeed = Mathf.Lerp(fpsStats.currentSpeed, targetSpeed, Time.deltaTime * 10);
        //Get a direction based on the button being pressed, normalize, and Move the characterController 
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.y ;
        direction.Normalize();
        characterController.Move(direction * fpsStats.currentSpeed * Time.deltaTime);
        //if is grounded and velocity on y is less than 0, don't keep adding speed down
        if (IsGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Add gravity and to drag character down
        velocity.y += fpsStats.gravity * Time.deltaTime;
        //move the character down based on gravity calculations
        characterController.Move(velocity * Time.deltaTime);
    }
    void JumpingPlayer()
    {
        //If is not grounded and no jumping
        if (IsGrounded() && !fpsStats.is_Jumping)
        {
            //Add force upward to make character jump
            velocity.y = Mathf.Sqrt(fpsStats.jumpForce * -2 * fpsStats.gravity);
        }
    }

    public void PlayerShot()
    {
        Animator.SetTrigger("Fire");
    }
    public void ShootWeapon()
    {
        GameManager.instance.weaponController.selectedWeapon.Shot();
    }

    #region --- Input/Functions ---
    public void OnMovement(InputAction.CallbackContext ctx)
    {
        //Chose what dirrection is moving and speed
        moveInput = ctx.ReadValue<Vector2>();
    }
    public void OnSprint()
    {
        //If us not jumping then switch sprinting 
        if(!fpsStats.is_Jumping)
        {
            fpsStats.is_Running = !fpsStats.is_Running;
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        
        if (!ctx.performed) return;
        JumpingPlayer();
    }
    #endregion
}
