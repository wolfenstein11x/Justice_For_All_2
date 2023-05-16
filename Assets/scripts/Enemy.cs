using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float walkSpeed = 2f;
    public float runSpeedMultiplier = 1.5f;
    [SerializeField] float sightRange = 10f;
    [SerializeField] LayerMask sightRaycastLayers;
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

    public bool InAttackMode()
    {
        bool inMeleeMode = animator.GetBool("meleeMode");
        bool inShootMode = animator.GetBool("shootMode");

        return (inMeleeMode || inShootMode);
    }

    public bool PlayerInSight()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * new Vector2(orientation, 0f), sightRange, sightRaycastLayers);

        // ray hit something, could be a wall or a target
        if (hit.collider != null)
        {
            // ray hit a target, because only a target would have Health
            if (hit.collider.gameObject.GetComponent<Health>() != null)
            {
                Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
                return true;
            }

            // ray hit a wall
            else
            {
                Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.yellow);
                return false;
            }

        }

        // ray hit nothing
        else
        {
            Debug.DrawRay(transform.position, Vector2.right * sightRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }
    }
}
