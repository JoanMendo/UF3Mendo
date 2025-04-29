using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;


[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PatrolNear", story: "Agent patrols near area", category: "Action/Navigation", id: "7b107ff004484f0a6c0dc66174127093")]
public partial class PatrolNearAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> distance;

    private Vector3 startingPoint;
    private Vector3 currentDestination;
    private NavMeshAgent agent;
    private bool validPosition = false;
    private float waitStartTime = 0f;
    private const float waitDuration = 1.2f;
    protected override Status OnStart()
    {
        startingPoint = Self.Value.transform.position;
        agent = Self.Value.GetComponent<NavMeshAgent>();
        PatrolNear();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (agent.remainingDistance < 0.2f)
        {
            waitStartTime += Time.deltaTime;
            if (waitStartTime > waitDuration)
            {
                waitStartTime = 0f;
                PatrolNear();
            }

        }
        
        return Status.Running;

    }


    public void PatrolNear()
    {

        int iterations = 0;
        
        do
        {
            iterations++;
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
            randomDirection += startingPoint;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, distance, NavMesh.AllAreas) && Vector3.Distance(hit.position, randomDirection) < 12)
            {
                Debug.DrawRay(hit.position, Vector3.up, Color.blue, 1.0f);
                validPosition = true;
                currentDestination = hit.position;
            }
            if (iterations > 100)
            {
                Debug.Log("Could not find a valid position");
                break;
            }
        } while (!validPosition);
        agent.SetDestination(currentDestination);
        agent.speed = 3f;

    }
}

