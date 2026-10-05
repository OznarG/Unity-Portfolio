using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RangeDetector", story: "Update Range [Detector] and assign [Target]", category: "Action", id: "54546094405fc62e5d8e2c6b71bdbb7a")]
public partial class RangeDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<RangeDetector> Detector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnUpdate()
    {
        //This is the variable(Sequence) in the blackboard so if the Value is false then fail, the player was not found and if it return true then success and 
        //pass the sequence
        Target.Value = Detector.Value.UpdateDetector();
        return Target.Value == null ? Status.Failure : Status.Success; 
    }

}

