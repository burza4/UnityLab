using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float startPoint;
    public float destinationPoint = 10;
    private bool movingToDestinationPoint = true;
    private bool isTriggerDetected = false;
    void Start()
    {
        startPoint = transform.position.x;
    }
    private void Update()
    {
        if (isTriggerDetected)
        {
            if (movingToDestinationPoint)
            {
                if (transform.position.x >= startPoint + destinationPoint)
                {
                    movingToDestinationPoint = false;
                }
                else
                {
                    transform.position += Vector3.right * Time.deltaTime;
                }
            }
            if (!movingToDestinationPoint)
            {
                if (transform.position.x <= startPoint)
                {
                    movingToDestinationPoint = true;
                    isTriggerDetected = false;
                }
                else
                {
                    transform.position += Vector3.left * Time.deltaTime;
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
