using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement2 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    private int currentWaypointIndex;
    private bool isTriggerDetected = false;
    public float speed = 10f;
    private bool isGoingBack = false;
    void Start()
    {
        currentWaypointIndex = 0;
    }
    private void Update()
    {

        if (isTriggerDetected)
        {
            float step = speed * Time.deltaTime;
            if (currentWaypointIndex < waypoints.Count - 1 && !isGoingBack)
            {
                if(transform.position == waypoints[currentWaypointIndex]) currentWaypointIndex++;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);
                Debug.Log("a " + currentWaypointIndex + " " + transform.position);
            }
            if (currentWaypointIndex == waypoints.Count - 1 && !isGoingBack)
            {
                isGoingBack = true;
                Debug.Log("b " + currentWaypointIndex + " " + transform.position);
            }
            if (currentWaypointIndex > 0 && isGoingBack)
            {
                if (transform.position == waypoints[currentWaypointIndex]) currentWaypointIndex--;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], step);
                Debug.Log("c " + currentWaypointIndex + " " + transform.position);
            }
            if (currentWaypointIndex == 0 && isGoingBack)
            {
                isGoingBack = false;
                Debug.Log("d " + currentWaypointIndex + " " + transform.position);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggerDetected = true;
        }
    }

}
