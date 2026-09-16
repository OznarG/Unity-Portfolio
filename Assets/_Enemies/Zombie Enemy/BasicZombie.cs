using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
//TODO, When the enemy dies he attacks again for some reason, need to solve that bug
public class BasicZombie : Enemy
{
    [Header("--- References ---")]
    [SerializeField] GameObject damageArea;
    BehaviorGraphAgent behaviorGraphAgent;
    [Header("-- Variables Condition/Control --")]
    public float follwDistance;
    public float distance;
    public float speed;
    public bool animating;
    [Header("--- Blackboard Vars ---")]
    public BlackboardVariable<bool> blackBoardPaused;
    public BlackboardVariable<bool> animatingBb;
    public BlackboardVariable<bool> TargetDetected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //Get Components needed
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        behaviorGraphAgent = GetComponent<BehaviorGraphAgent>();
        //Get Scripts from Blackboard
        behaviorGraphAgent.BlackboardReference.GetVariable("PauseNodes", out blackBoardPaused);
        behaviorGraphAgent.BlackboardReference.GetVariable("Animating", out animatingBb);
    }

    // Update is called once per frame
    void Update()
    {
        //Set animator Speed to match blend animation tree
        animator.SetFloat("Speed", agent.velocity.magnitude);
        speed = agent.velocity.magnitude;
        RotateTowardsPlayer();      
    }
    void RotateTowardsPlayer()
    {
        //Get direction towards player
        Vector3 dir = GameManager.instance._playerObj.transform.position - transform.position;
        //prevent tilting up/down
        dir.y = 0;
        //Get value from blackboard variable
        behaviorGraphAgent.BlackboardReference.GetVariableValue("TargetDetected", out TargetDetected);
        //Condition to rotate, rotate if is not moving and if is chasing the player
        if (agent.velocity.sqrMagnitude < 0.1f && TargetDetected)
        {
            //Get the rotation to rotate to
            Quaternion targetRot = Quaternion.LookRotation(dir);
            //rotate to the destination(Target) 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }
    //Method for when health hits 0 and the enemie dies*
    public void Die()
    {
        //Set Blackboard variable so it pauses the nodes
        behaviorGraphAgent.BlackboardReference.SetVariableValue("PauseNodes", true);
        //Stoped Agent so it can't move anymore and Srt Dead to true
        agent.isStopped = true;
        animator.SetTrigger("Dead");
        //set condition animating to true so it doesn't call the attacks
        animator.SetBool("animating", true);
        //Destroyed the game object 4 seconds after
        Destroy(gameObject, 4);
    }
    public void Attack()
    {
        //Set Attack Trigger
        animator.SetTrigger("Attack");
    }
    public override void TakeDamage(float amount)
    {
        //Add Damage adn check if is bellow
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    //This region was for Opsite BT
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
    //Set attacking animating to true so the enemy cannot attack again
    public void Attacking()
    {
        behaviorGraphAgent.BlackboardReference.SetVariableValue("Animating", true);
        animator.SetBool("animating", true);
        animating = true;
    }
    //Set attacking animating to false so the enemy cannot attack again
    public void EndAttacking()
    {
        animating = false;
        behaviorGraphAgent.BlackboardReference.SetVariableValue("Animating", false);
        animator.SetBool("animating", false);
    }
    //turn on the samage area or off
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
