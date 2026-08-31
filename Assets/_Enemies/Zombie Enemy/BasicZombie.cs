using UnityEngine;
using UnityEngine.AI;

public class BasicZombie : Enemy, IDamage
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        agent = GetComponent<NavMeshAgent>();      
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
