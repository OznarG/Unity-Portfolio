using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombie : Enemy, IDamage
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public  void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {      
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void Die()
    {
        
        agent.isStopped = true;
        
    }
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    
    }
}
