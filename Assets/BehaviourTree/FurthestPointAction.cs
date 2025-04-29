using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FurthestPoint", story: "Given a set of Waypoints, select the one that is furthest away", category: "Action/Navigation", id: "0e8a319014ea41ae99f6dc265afca9b6")]
internal partial class GetFurthestPointAction : Action
{
    [SerializeReference] public BlackboardVariable<List<GameObject>> WaypointsEnemigo;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> TargetWaypoint;


    protected override Status OnStart()
    {
        if (WaypointsEnemigo.Value == null || WaypointsEnemigo.Value.Count == 0)
        {
            LogFailure("No waypoints to patrol assigned.");
            return Status.Failure;
        }

        SelectFurthestWaypoint();
        return Status.Success;
    }


    public void SelectFurthestWaypoint()
    {    
        NavMeshPath path = new NavMeshPath();
        
        float maxDistance = 0;
        for (int i = 0; i < WaypointsEnemigo.Value.Count; i++)
        {

            float distance = 0;
            NavMesh.SamplePosition(Self.Value.transform.position, out NavMeshHit hit, 2f, NavMesh.AllAreas);
            NavMesh.CalculatePath(hit.position, WaypointsEnemigo.Value[i].transform.position, NavMesh.AllAreas, path);
            Debug.Log(Self.Value.transform.position);
            for (int j = 0; j < path.corners.Length - 1; j++)
            {

                distance += Vector3.Distance(path.corners[j], path.corners[j + 1]);
            }
            if (distance > maxDistance)
            {
                maxDistance = distance;

                TargetWaypoint.Value = WaypointsEnemigo.Value[i];

            }
        }


    }
}



