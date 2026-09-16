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
    [SerializeField] GameObject damageArea;
    BehaviorGraphAgent behaviorGraphAgent;
    public BlackboardVariable<bool> blackBoardPaused;
    public BlackboardVariable<bool> animatingBb;
    public BlackboardVariable<bool> TargetDetected;

    public float reminingDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
       agent = GetComponent<NavMeshAgent>();
       animator = GetComponent<Animator>();
        behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
        if (behaviorGraphAgent == null )
        {
            Debug.Log("Couldn't get variable");
        }
        behaviorGraphAgent.BlackboardReference.GetVariable("PauseNodes", out blackBoardPaused);
        behaviorGraphAgent.BlackboardReference.GetVariable("Animating", out animatingBb);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, GameManager.instance._playerObj.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);
        speed = agent.velocity.magnitude;
        RotateTowardsPlayer();
        
    }
    void RotateTowardsPlayer()
    {
        Vector3 dir = GameManager.instance._playerObj.transform.position - transform.position;
        dir.y = 0; // prevent tilting up/down
        reminingDistance = agent.remainingDistance;
        behaviorGraphAgent.BlackboardReference.GetVariable("TargetDetected", out TargetDetected);
        Debug.Log(TargetDetected);
        if (agent.velocity.sqrMagnitude < 0.1f && TargetDetected)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }
    public void Die()
    {
        blackBoardPaused.ObjectValue = true;
        behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
        behaviorGraphAgent.BlackboardReference.SetVariableValue("PauseNodes", true);

        agent.isStopped = true;
        animator.SetTrigger("Dead");
        animator.SetBool("animating", true );
        Debug.Log("DEADDD");    
        Destroy(gameObject, 2);
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
        behaviorGraphAgent.BlackboardReference.SetVariableValue("Animating", true);
        animator.SetBool("animating", true);
        animating = true;
    }
    public void EndAttacking()
    {
        animating = false;
        behaviorGraphAgent.BlackboardReference.SetVariableValue("Animating", false);
        animator.SetBool("animating", false);
    }
    public void TurnOnDamageArea()
    {
        damageArea.SetActive(true);
    }
    public void TurnOffDamageArea()
    {
        damageArea.SetActive(false);
    }
    #endregion
}
