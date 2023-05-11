using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float meleeRange = 1f;
    [SerializeField] Transform meleePos;
    [SerializeField] float meleeDamage;

    Rigidbody2D rb;
    OrientationTracker orientationTracker;
    LayerMask meleeRaycastLayers;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientationTracker = GetComponent<OrientationTracker>();
        meleeRaycastLayers = LayerMask.GetMask("Player");
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

    public void Halt()
    {
        rb.velocity = new Vector2(0f, 0f);
    }

    public bool InMeleeRange()
    {
        float orientation = orientationTracker.GetOrientation();

        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        
        if (hitMelee.collider != null)
        {
            Debug.DrawRay(meleePos.position, Vector2.right * hitMelee.distance * new Vector2(orientation, 0f), Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(meleePos.position, Vector2.right * meleeRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }

    public void InitiateMeleeAttack()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        if (hitMelee.collider.gameObject.GetComponent<Health>() != null)
        {
            Health targetHealth = hitMelee.collider.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(meleeDamage);
        }
    }

    public void DealDamage(float damage)
    {
        //Debug.Log("damage: " + damage);
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
