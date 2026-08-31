using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float walkSpeed;
    public float runSpeed;
    public float damage;
    public NavMeshAgent agent;

    public abstract void Attack();
}
