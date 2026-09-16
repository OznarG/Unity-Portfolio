using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterStats : MonoBehaviour, IDamage
{
    //TODO: Add flash screen when taking damage

    //Player Stats Basic
    public float health;
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
    public HealthManager healthManager;

    void Start()
    {
        //get health maneger
        healthManager = GetComponent<HealthManager>();
    }
    //static method Idamage so it can be called to take damage
    public void AddEffect(WoundTypes type, BodyParts bodyPart)
    {       
        healthManager.ChooseEffect(type, bodyPart);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
