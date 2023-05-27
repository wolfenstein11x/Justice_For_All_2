using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBlast : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float damage = 10f;
    [SerializeField] float maxLifetime = 1f;
    [SerializeField] float explosionLifetime = 0.2f;
    [SerializeField] float explosionSoundLifetime = 1.2f;
    [SerializeField] GameObject impactVFX;
    [SerializeField] GameObject impactSound;

    private Rigidbody2D rb;
    private float orientation;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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

    public void BlowUp()
    {
        // show bullet explosion where bullet hits
        GameObject bulletExplosion = Instantiate(impactVFX, transform.position, transform.rotation);

        if (impactSound != null)
        {
            GameObject explosionSound = Instantiate(impactSound, transform.position, transform.rotation);
            Destroy(explosionSound, explosionSoundLifetime);
        }

        Destroy(bulletExplosion, explosionLifetime);

        Destroy(gameObject);
    }
}
