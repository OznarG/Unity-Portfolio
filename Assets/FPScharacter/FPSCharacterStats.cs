using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterStats : MonoBehaviour
{
    public float currentSpeed;
    public float walkSpeed;
    public float runningSpeed;
    public float jumpForce;
    public float gravity;
    public bool is_Jumping;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
