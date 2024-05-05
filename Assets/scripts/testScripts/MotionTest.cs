using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTest : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    public void Move()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    public void JumpDiagonalUp()
    {
        rb.velocity = new Vector2(moveSpeed, jumpSpeed);
    }

    public void JumpUp()
    {
        rb.velocity = new Vector2(0f, jumpSpeed);
    }

    public void JumpDiagonalDown()
    {
        rb.velocity = new Vector2(moveSpeed, -jumpSpeed);
    }

    public void EndJump()
    {
        animator.SetBool("jumping", false);
    }

    

    

    public void TurnAround()
    {
        //Debug.Log(moveSpeed);
        moveSpeed = -moveSpeed;
        FlipSprite();
        //Debug.Log(moveSpeed);
    }

    public void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TurnAround();
        //moveSpeed = -moveSpeed;
        //FlipSprite();
    }
}
