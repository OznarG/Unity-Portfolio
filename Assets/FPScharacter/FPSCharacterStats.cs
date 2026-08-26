using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterStats : MonoBehaviour
{
    public float walkSpeed;
    public float runningSpeed;
    public float jumpForce;
    public float gravity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
