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

    public void AddEffect()
    {
        throw new System.NotImplementedException();
    }

    public abstract void TakeDamage(float amount);
}
