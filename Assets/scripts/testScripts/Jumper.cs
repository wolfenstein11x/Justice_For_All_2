using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpUpSpeed = 1f;
    [SerializeField] float jumpDownSpeed = 1f;

    Rigidbody2D rb;
    Animator animator;
    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpDiagonalUp()
    {
        animator.SetTrigger("jump");
        float moveSpeed = enemy.MoveSpeed();
        rb.velocity = new Vector2(moveSpeed, jumpUpSpeed);
    }

    public void JumpUp()
    {
        rb.velocity = new Vector2(0f, jumpUpSpeed);
        
    }

    public void JumpDiagonalDown()
    {
        animator.SetTrigger("jump");
        float moveSpeed = enemy.MoveSpeed();
        rb.velocity = new Vector2(moveSpeed, -jumpDownSpeed);
    }

    public void EndJump()
    {
        rb.velocity = new Vector2(enemy.MoveSpeed(), 0f);
    }
}
