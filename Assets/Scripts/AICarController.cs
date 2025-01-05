using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints
    public float speed = 5f; // Speed of the car
    public float detectionRadius = 2f; // Radius for detecting collisions
    public LayerMask obstacleLayer; // Layer mask for obstacles

    private int currentWaypointIndex = 0; // Current waypoint index
    private bool isStopped = false; // Flag to check if the car is stopped

    void Update()
    {
        if (waypoints.Count == 0) return; // Ensure waypoints are assigned

        if (!isStopped)
        {
            MoveTowardsWaypoint();
        }

        CheckForObstacles();
    }

    void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetWaypoint.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(targetWaypoint);

        // Check if the car is close to the waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // Loop back to the first waypoint
            }
        }
    }

    void CheckForObstacles()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, obstacleLayer);

        if (hitColliders.Length > 0)
        {
            isStopped = true; // Stop the car if obstacles are detected
        }
        else
        {
            isStopped = false; // Resume movement if no obstacles are detected
        }
    }

    void OnDrawGizmos()
    {
        // Draw the detection radius in the scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
