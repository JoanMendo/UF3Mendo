using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SuffleWaypoints", story: "Given a list of waypoints for a NavAgent to patrol, reorder randomly those waypoints", category: "Action/Navigation", id: "60bca198061706b45fcfa2dc9f1a0671")]
internal partial class SuffleWaypointsAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> Waypoints;


    protected override Status OnStart()
    {
        if (Waypoints.Value == null || Waypoints.Value.Count == 0)
        {
            LogFailure("No waypoints to patrol assigned.");
            return Status.Failure;
        }

        ShuffleWaypoints();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    public void ShuffleWaypoints()
    {
        
       
        List<GameObject> shuffledWaypoints = new List<GameObject>(Waypoints.Value);

        // Baraja la lista
        for (int i = 0; i < shuffledWaypoints.Count; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, shuffledWaypoints.Count);
            GameObject temp = shuffledWaypoints[i];
            shuffledWaypoints[i] = shuffledWaypoints[randomIndex];
            shuffledWaypoints[randomIndex] = temp;
        }

        for (int i = 0; i < shuffledWaypoints.Count; i++)
        {
            Waypoints.Value[i] = shuffledWaypoints[i];

        }

    }
}

