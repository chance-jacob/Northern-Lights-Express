using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;

    private float velocity;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Amimate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Amimate()
    {
        animator.SetFloat("AnimateMoveX", moveDirection.x);
        animator.SetFloat("AnimateMoveY", moveDirection.y);
        animator.SetFloat("AnimateLastMoveX", lastMoveDirection.x);
        animator.SetFloat("AnimateLastMoveY", lastMoveDirection.y);
        animator.SetFloat("AnimateMoveMagnitude", moveDirection.magnitude);
    }


}

