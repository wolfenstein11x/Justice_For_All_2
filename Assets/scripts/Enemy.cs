using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float meleeRange = 1f;

    Rigidbody2D rb;
    OrientationTracker orientationTracker;
    LayerMask meleeRaycastLayers;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientationTracker = GetComponent<OrientationTracker>();
        LayerMask meleeRaycastLayers = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Patrol()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    public void FlipSprite()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }

    public bool InMeleeRange()
    {
        float orientation = orientationTracker.GetOrientation();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        if (!hit) { return false; }

        if (hit.collider.gameObject.tag == "Player")
        {
            Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.green);
            return false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipSprite();
    }
}
