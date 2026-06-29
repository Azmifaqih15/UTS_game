using UnityEngine;

public class SimpleAICar : MonoBehaviour
{
    public Transform[] waypoints;

    public float speed = 15f;
    public float turnSpeed = 5f;

    private int currentWaypoint = 0;

    void Update()
    {

        
        // Tunggu countdown selesai
        if (!RaceCountdown.raceStarted)
        {
            return;
        }

        // Cek apakah waypoint ada
        if (waypoints.Length == 0)
        {
            return;
        }

        Transform target = waypoints[currentWaypoint];

        Vector3 direction =
            (target.position - transform.position).normalized;

        Quaternion lookRotation =
            Quaternion.LookRotation(direction);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                lookRotation,
                turnSpeed * Time.deltaTime
            );

        transform.position +=
            transform.forward * speed * Time.deltaTime;

        float distance =
            Vector3.Distance(
                transform.position,
                target.position
            );

        if (distance < 5f)
        {
            currentWaypoint++;

            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }
}