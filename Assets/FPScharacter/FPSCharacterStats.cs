using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCharacterStats : MonoBehaviour, IDamage
{
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

    public void AddEffect()
    {
        Wound wound = gameObject.AddComponent<Wound>();
       
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Damage Taken");
    }
}
