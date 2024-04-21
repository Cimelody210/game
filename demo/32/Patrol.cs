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
        transform.position =  Vector2.MoveTowards(transform.position, parto)
    }
}