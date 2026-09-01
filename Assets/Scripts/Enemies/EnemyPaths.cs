using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;
using UnityEngine.AI;


public class EnemyPaths : Action
{
    public SharedVariable<float> radious = 5.0f;
    protected Vector3 _StartingPoint;
    public NavMeshAgent agent;
    BasicZombie zombie;
    
    public override  void OnStart()
    {
        _StartingPoint = transform.position;   
        zombie = this.gameObject.GetComponentInParent<BasicZombie>();
        agent = this.gameObject.GetComponentInParent<NavMeshAgent>();
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        DetermineDestinationPoint();
        return base.OnUpdate();
    }
    public Vector3 destination;
    private void DetermineDestinationPoint()
    {
        if(destination == Vector3.zero)
        {
            destination = GetRandomPointInSphere();

            agent.SetDestination(destination);
        }
    }

    private Vector3 GetRandomPointInSphere()
    {
        Vector3 generateDest = Random.insideUnitSphere * radious.Value;

        float adjY = _StartingPoint.y + 0.01f;

        Vector2 desiredDestination = new Vector3(generateDest.x + _StartingPoint.x, adjY, generateDest.z + _StartingPoint.z);

        return desiredDestination;
    }
}
