using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterStats : MonoBehaviour
{
    //Variables to control speed
    public float currentSpeed;
    public float walkSpeed;
    public float runningSpeed;
    public float jumpForce;
    public float gravity;
    //Condition Checkers 
    public bool is_Jumping;
    public bool is_Running;
    public float groundDistance = 0.4f;
    //Components and References
    public Transform groundCheck;
    public LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set the walk speed at start
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
