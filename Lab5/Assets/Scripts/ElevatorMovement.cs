using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private float startPoint;
    public float destinationPoint = 4;
    private bool isGoindToDestinationPoint = true;
    private bool isTriggerDetected = false;
    void Start()
    {
        startPoint = transform.position.y;
    }
    private void Update()
    {
        if (isTriggerDetected)
        {
            if (isGoindToDestinationPoint)
            {
                if (transform.position.y >= startPoint + destinationPoint)
                {
                    isGoindToDestinationPoint = false;
                }
                else
                {
                    transform.position += Vector3.up * Time.deltaTime;
                }
            }
            if (!isGoindToDestinationPoint)
            {
                if (transform.position.y <= startPoint)
                {
                    isGoindToDestinationPoint = true;
                    isTriggerDetected = false;
                }
                else
                {
                    transform.position += Vector3.down * Time.deltaTime;
                }
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
    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTriggerDetected = false;
        }
    }*/
}
