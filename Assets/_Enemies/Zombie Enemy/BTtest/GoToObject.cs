using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;
using UnityEngine.AI;


public class GoToObject : Action
{
    [SerializeField] SharedVariable<GameObject> destination;
    [SerializeField] SharedVariable<float> ArriveDistance = 0.5f;

    NavMeshAgent agent;

    public override void OnAwake()
    {
        base.OnAwake();

        agent = gameObject.GetComponentInParent<NavMeshAgent>();
    }

    public override void OnStart()
    {
        agent.isStopped = false;
        agent.SetDestination(destination.Value.transform.position);
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(agent.destination != destination.Value.transform.position)
        {
            agent.SetDestination(destination.Value.transform.position);
        }
        if(agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            return TaskStatus.Failure;
        }
        if(HasArrived())
        {
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        if(agent.isOnNavMesh)
        {
            agent.isStopped = true;
        }
    }
    bool HasArrived()
    {
        return Vector3.Distance(destination.Value.transform.position, agent.transform.position) <= ArriveDistance.Value;
    }
}
