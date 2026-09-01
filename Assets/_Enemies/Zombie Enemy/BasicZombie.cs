using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombie : Enemy, IDamage
{
    public float follwDistance;
    public float distance;
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public  void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, GameManager.instance._playerObj.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        speed = agent.velocity.magnitude;
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    public void Die()
    {
        
        agent.isStopped = true;
        
    }
    #region ---Setters and Getters for Tree ---

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
    public float FollowDistance
    { get { return follwDistance; } set { follwDistance = value; } }
    public float Distance
    { get { return distance; } set { distance = value; } }
    #endregion
}
