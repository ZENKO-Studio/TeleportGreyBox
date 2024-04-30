using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class PathFollow : ArriveSteeringBehaviour
{
    public float waypointDistance = 0.5f; // Distance at which the waypoint is considered "reached"
    public int cornerIndex = 0;
    public int wayPointIndex = 0;
    public bool shouldLoop = true; // Flag to control looping behavior
    private NavMeshPath path;
    public Transform[] waypoints; // The waypoints to follow

    void Start()
    {
        path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, waypoints[wayPointIndex].position, NavMesh.AllAreas, path);
        target = waypoints[0].position;
    }

    public override Vector3 CalculateForce()
    {
        if (cornerIndex < path.corners.Length && (target - transform.position).magnitude < waypointDistance)
        {
            target = path.corners[cornerIndex];
            cornerIndex++;
        }

        if ((waypoints[wayPointIndex].position - transform.position).magnitude < waypointDistance)
        {
            if (wayPointIndex < waypoints.Length - 1)
            {
                wayPointIndex++;
            }
            else if (shouldLoop)
            {
                wayPointIndex = 0; // Loop back to the first waypoint
            }

            cornerIndex = 0;
            NavMesh.CalculatePath(transform.position, waypoints[wayPointIndex].position, NavMesh.AllAreas, path);
        }

        return CalculateArriveForce();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        DebugExtension.DrawCircle(target, Color.magenta, waypointDistance);

        if (path != null && path.corners.Length > 0)
        {
            DebugExtension.DrawCircle(path.corners[path.corners.Length - 1], Color.magenta, 1f);
            for (int i = 1; i < path.corners.Length; i++)
            {
                Debug.DrawLine(path.corners[i - 1], path.corners[i], Color.black);
                DebugExtension.DrawCircle(path.corners[i - 1], Color.magenta, 0.2f);
            }
        }
    }
}
