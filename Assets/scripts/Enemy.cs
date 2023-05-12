using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] bool hideMode = false;
    
    Rigidbody2D rb;
    OrientationTracker orientationTracker;
    Animator animator;


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
    }

    

    public void Patrol()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    public void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

    public void Halt()
    {
        rb.velocity = new Vector2(0f, 0f);
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
}
