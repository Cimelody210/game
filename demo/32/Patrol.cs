using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class Patrol: MonoBehaviour
{
    // :Enemy
    public Transform[] patrolPoints;
    public float speed;
    int currentPointIndex = 1;
    float waitTime;
    Animator animator;

    public float startWaitTime;

    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime  = startWaitTime;
        animator =  GetComponent<Animator>();
    }
    void Update()
    {
        // No update
        transform.position =  Vector2.MoveTowards(transform.position, partrolPoints[currentPointIndex].position, speed= Time.deltaTime);
        if(transform.position == patrolPoints[currentPointIndex].position)
        {
            animator.SetBoo("isRunning", false);
            if (waitTime ==0)
            {
                if(currentPointIndex + 1 < partrolPoints.Length){
                    currentPointIndex++;
                }
                else 
                {
                    currentPointIndex = 0;
                }
                waitTime =  startWaitTime;
            }
            else {
                waitTime =  Time.deltaTime;
            }
        }
        else {
            animator.SetBoo("isRunning", true);
        }
    }
}