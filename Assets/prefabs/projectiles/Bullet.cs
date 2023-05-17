using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float damage = 10f;
    [SerializeField] float maxLifetime = 1f;
    [SerializeField] GameObject impactVFX;

    private Rigidbody2D rb;
    private float orientation;
    SpriteRenderer sr, srParent, srImpact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        srParent = GetComponentInParent<SpriteRenderer>();
        orientation = GetComponentInParent<OrientationTracker>().GetOrientation();

        // set sorting layer to same as the person shooting, so that bullet is visible indoors
        sr.sortingLayerName = srParent.sortingLayerName;

        // de-child bullet from shooter so it does not move with shooter
        transform.parent = null;

        Destroy(gameObject, maxLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * orientation, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }

        // show bullet explosion where bullet his
        GameObject bulletExplosion = Instantiate(impactVFX, transform.position, transform.rotation);

        // make bullet explosion sorting layer same as that of the bullet so we can see it indoors
        srImpact = bulletExplosion.GetComponent<SpriteRenderer>();
        srImpact.sortingLayerName = sr.sortingLayerName;

        Destroy(bulletExplosion, 0.2f);
        Destroy(gameObject);
    }


}
