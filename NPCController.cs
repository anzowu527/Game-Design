using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Vector3[] waypoints;
    public float waypointReachedThreshold = 0.5f;

    private NavMeshAgent navMeshAgent;
    private int currentWaypoint = 0;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypoint]);
        }
    }

    void Update()
    {
        if (waypoints.Length > 0 && !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= waypointReachedThreshold)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypoint]);
        }
    }
}


