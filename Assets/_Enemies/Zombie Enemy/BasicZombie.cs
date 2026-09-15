using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombie : Enemy
{
    public float follwDistance;
    public float distance;
    public float speed;
    public bool animating;

    public BlackboardVariable<bool> blackBoardPaused;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public  void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();
       BehaviorGraphAgent behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
        if (behaviorGraphAgent == null )
        {
            Debug.Log("Couldn't get variable");
        }
        behaviorGraphAgent.BlackboardReference.GetVariable("PauseNodes", out blackBoardPaused);
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, GameManager.instance._playerObj.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        speed = agent.velocity.magnitude;
        
    }

    public void Die()
    {
        blackBoardPaused.ObjectValue = true;
        BehaviorGraphAgent behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
        behaviorGraphAgent.BlackboardReference.SetVariableValue("PauseNodes", true);

        agent.isStopped = true;
        animator.SetTrigger("Dead");
        Debug.Log("DEADDD");    
    }
    public void DestroyZombie()
    {
        Destroy(gameObject);
    }
    public void Attack()
    {
        Debug.Log("Attacking motherfuckers");
        animator.SetTrigger("Attack");
    }
    public override void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
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
    public bool Animating
    { get { return animating; } set { animating = value; } }
    #endregion
    #region ---ANIMATION EVENT---
    public void Attacking()
    {
        animating = true;
    }
    public void EndAttacking()
    {
        animating = false;
    }
    #endregion
}
