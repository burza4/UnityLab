using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement2D : MonoBehaviour
{
	public float setSpeed=1;
	public bool isMovingRight;
    public Animator animator;
    public Transform pointA;
    public Transform pointB;
    private Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        CheckIfTargetIsNear();
        if (isMovingRight)
        {
            transform.Translate(1 * Time.deltaTime * setSpeed, 0, 0);
            animator.SetFloat("Speed", Mathf.Abs(1 * Time.deltaTime * setSpeed));
            transform.localScale = new Vector2(0.2f, 0.2f);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * setSpeed, 0, 0);
            animator.SetFloat("Speed", Mathf.Abs(-1 * Time.deltaTime * setSpeed));
            transform.localScale = new Vector2(-0.2f, 0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Edge"))
        {
            isMovingRight = !isMovingRight;
        }
    }
    private void CheckIfTargetIsNear()
    {
        if (target.position.x >= pointA.position.x && target.position.x<=transform.position.x)
        {
            isMovingRight = false;
        }
        if(target.position.x <= pointB.position.x && target.position.x >= transform.position.x)
        {
            isMovingRight = true;
        }
    }
}
