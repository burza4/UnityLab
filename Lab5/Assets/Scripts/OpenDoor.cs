using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private float startPoint;
    private float destinationPoint = 4;
    private bool isTriggerDetected = false;
    void Start()
    {
        startPoint = transform.position.z;

    }
    private void Update()
    {
        if (isTriggerDetected)
        {
            if (transform.position.z < destinationPoint+startPoint)
            {
                transform.position += Vector3.forward * Time.deltaTime;
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
