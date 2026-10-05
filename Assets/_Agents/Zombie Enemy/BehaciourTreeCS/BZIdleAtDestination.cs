using Opsive.BehaviorDesigner.Runtime.Tasks;
using Opsive.BehaviorDesigner.Runtime.Tasks.Actions;
using Opsive.GraphDesigner.Runtime.Variables;
using UnityEngine;

public class BZIdleAtDestination : Action
{
    public SharedVariable<bool> hasReachedDestination;
    public SharedVariable<bool> resetWander;
    private float _curentTime;
    public SharedVariable<float> maxWaitTime;


    public override void OnStart()
    {
        base.OnStart();
    }


    public override TaskStatus OnUpdate()
    {
        if(hasReachedDestination == null || hasReachedDestination.Value)
        {
            return TaskStatus.Failure;
        }
        hasReachedDestination.Value = true;

        bool isIdling = IsNPCInling();
        if (isIdling) { return TaskStatus.Running; }

        resetWander.Value = true;
        return base.OnUpdate();
    }


    private bool IsNPCInling()
    {
       if(_curentTime < maxWaitTime.Value)
        {
            _curentTime += Time.deltaTime;
            return true;
        }
       _curentTime = 0f;
        return false;
    }
}
