using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public GameObject movementBox;

    public enum MovementPattern {Horizontal, Vertical}

    public int speed;
    public int direction = 1; // 1 for left -1 for right
    public MovementPattern movementPattern;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetInteger("Speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement(); // CHANGE TO UPDATE MOVEMENT
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject == movementBox) && (movementPattern == MovementPattern.Horizontal))
            Flip();
    }

    public void Flip()
    {
        // Change direction
        direction *= -1;
        // Change Object direction
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public void Move()
    {
        // Udate Animator's speed value
        animator.SetInteger("Speed", speed);

        // Get frame's character movement value
        float timeMove = direction * speed * Time.fixedDeltaTime;

        // X and Y movement depend on movement pattern
        float xMove = movementPattern == MovementPattern.Horizontal ? timeMove : rigidBody2D.velocity.x;
        float yMove = movementPattern == MovementPattern.Horizontal ? rigidBody2D.velocity.y : timeMove;

        rigidBody2D.velocity = new Vector2(xMove, yMove);
    }

    public void StopMoving()
    {
        // Udate Animator's speed value
        animator.SetInteger("Speed", 0);

        rigidBody2D.velocity = new Vector2(0, 0);
    }

    private bool isActing() 
    {
        return ((animator.GetBool("isAttacking") || animator.GetBool("isDying") || animator.GetBool("isDamaged")) ? true : false);
    }

    public void UpdateMovement()
    {
        if (isActing())
            StopMoving();
        else
            Move();
    }
}
