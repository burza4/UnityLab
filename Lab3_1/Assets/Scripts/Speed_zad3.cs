using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_zad3 : MonoBehaviour
{
    public float speed = 2.0f;
    public float maxDistance = 4;
    private float movedDistance = 0.0f;
    private Vector3 oldPosition = Vector3.zero;
    void Start()
    {
        oldPosition = transform.position;
    }
    void Update()
    {
        Vector3 x = oldPosition - transform.position;
        movedDistance += Mathf.Abs(x.magnitude);
        //print(movedDistance);
        oldPosition = transform.position;
        if (movedDistance > maxDistance)
        {
            transform.Rotate(Vector3.up * 90);
            movedDistance = 0.0f;
        }
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
