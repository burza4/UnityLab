using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_zad2 : MonoBehaviour
{
    public float speed = 2.0f;
    private int direction = 1;
    public float maxDistance = 4;
    private float movedDistance = 0.0f;
    private Vector3 oldPosition = Vector3.zero;
    void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {
        movedDistance += Mathf.Abs(oldPosition.x - transform.position.x);
        //print(movedDistance);
        oldPosition = transform.position;
        if (movedDistance > maxDistance)
        {
            direction = -direction;
            movedDistance = 0.0f;
        }
        transform.Translate(Vector3.right * direction * Time.deltaTime * speed);
    }
}
