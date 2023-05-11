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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientation = GetComponentInParent<OrientationTracker>().GetOrientation();
        
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
        GameObject bulletExplosion = Instantiate(impactVFX, transform.position, transform.rotation);
        Destroy(bulletExplosion, 0.2f);
        Destroy(gameObject);
    }


}
