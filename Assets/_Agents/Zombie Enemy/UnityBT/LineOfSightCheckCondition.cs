using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Line of Sight Check", story: "Check [Target] With Line of Sight [Detector]", category: "Conditions", id: "f21c7c3028f2a68ea37753f359a08d59")]
public partial class LineOfSightCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<LineOfSight> Detector;

    public override bool IsTrue()
    {
        //This is a blackboard sequence check that return true if is not null, so if the player is returned then is true
        return Detector.Value.PerformDetection(Target.Value) != null;
    }

}
