using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamage
{
    public NavMeshAgent agent;
    public Transform target;
    public Animator animator;

    public float health;
    public float walkSpeed;
    public float runSpeed;
    public float damage;

    public abstract void TakeDamage(float amount);
}
