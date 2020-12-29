using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        moveSpeed = 0;
        animator.SetFloat("MovementSpeed", moveSpeed);
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        moveSpeed = 3;
        animator.SetFloat("MovementSpeed", moveSpeed);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }


}

