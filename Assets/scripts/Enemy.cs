using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    public float runSpeedMultiplier = 1.5f;
    [SerializeField] float jumpSpeed;
    [SerializeField] bool hideMode = false;
    
    Rigidbody2D rb;
    OrientationTracker orientationTracker;
    Animator animator;
    float moveSpeed;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("hideMode", hideMode);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientationTracker = GetComponent<OrientationTracker>();
        moveSpeed = walkSpeed;
    }

    

    public void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
        Vector2 jumpForce = new Vector2(0f, jumpSpeed);
        rb.AddForce(jumpForce);
    }

    public void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

    public void Halt()
    {
        rb.velocity = new Vector2(0f, 0f);
    }

    public void MultiplySpeed(float speedMultiplier)
    {
        moveSpeed = moveSpeed * speedMultiplier;
    }

    public void RemoveFromPlay()
    {
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipSprite();
    }

    public void TurnAround()
    {
        moveSpeed = -moveSpeed;
        FlipSprite();
    }
}
