using System;
using System.Collections.Generic;
using System.UnityEngine;
using System.Drawing;
using Unity.VisualScripting;

public class Player: MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("WallBottom"))
        {
            jumpCount = 0;
        }
    }
    private void AttackRing()
    {
        animator.SetBool("Powe-shot", true);
        GameObject chuong = Instantiate(shot, transform.position, Quaternion.identity);
        Vector3 direction = transform.right;

        if(transform.localState.x < 0)
        {
            direction *= -1;
        }
        MoveScript move = chuong.GetComponent<MoveScript>();
        if( move != null)
        {
            move.direction  = direction;
        }
    }
    void Start()
    {
        Time.timeScale = 1f;
        isDead  =false;
        rb = GetComponent<Rigidbody2D>();
        animator=   GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        if(isDead)
        {
            GameOver();
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity  = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        animator.GetKeyDown("walk", Mathf.Abs(moveInput));

        if(Input.GetKeyDown(KeyCode.A))
        {
            AttackRing();
        }
        else
        {
            animator.SetBoo("powe-shoot", false);
        }

    }
}