using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Agent Runs Away", story: "[Agents] runs away for [five] seconds", category: "Action", id: "053ed4449b486561672876a18b9a1b8d")]
public partial class AgentRunsAwayAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agents;
    [SerializeReference] public BlackboardVariable<float> Five;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

