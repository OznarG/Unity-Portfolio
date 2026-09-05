using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttacks : Action
{
    [SerializeField] SharedVariable<GameObject> destination;
    [SerializeField] SharedVariable<float> AttackDistance = 0.5f;

    public NavMeshAgent agent;

    public override void OnAwake()
    {
        base.OnAwake();

        agent = gameObject.GetComponentInParent<NavMeshAgent>();
    }

    public override void OnStart()
    {   
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {       
        if (!HasArrived())
        {
            return TaskStatus.Failure;
        }
        if (HasArrived())
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        if (agent.isOnNavMesh)
        {
            agent.isStopped = true;
        }
    }
    bool HasArrived()
    {
        return Vector3.Distance(destination.Value.transform.position, agent.transform.position) <= AttackDistance.Value;
    }

    public void Attack()
    {
        Debug.Log("Attacking motherfuckers");
    }
}
