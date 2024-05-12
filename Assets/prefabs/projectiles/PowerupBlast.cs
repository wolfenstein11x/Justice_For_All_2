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
    [SerializeField] float fadeAwaySpeed = 1000f;
    [SerializeField] GameObject impactVFX;
    [SerializeField] GameObject impactSound;

    private Rigidbody2D rb;
    private float orientation;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        orientation = GetComponentInParent<OrientationTracker>().GetOrientation();

        // de-child bullet from shooter so it does not move with shooter
        transform.parent = null;

        // powerup blasts may not be symmetric, so make it face direction it's going
        transform.localScale = new Vector2(orientation * transform.localScale.x, transform.localScale.y);

        Invoke(nameof(FadeAway), maxLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * orientation, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health targetHealth = collision.gameObject.GetComponent<Health>();
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        // hit enemy bullet, destroy bullet and keep going
        if (bullet != null)
        {
            bullet.BlowUp();
        }

        // hit something with health, deal damage and blow up
        else if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);

            DisableColliders();

            FadeAway();
        }

        // hit wall or another powerup blast, blow up
        else
        {
            FadeAway();
            //DisableColliders();
        }
    }

    private void DisableColliders()
    {
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
    }

    private void FadeAway()
    {
        StartCoroutine(FadeAwayCoroutine());
    }

    IEnumerator FadeAwayCoroutine()
    {
        Color c = sr.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            sr.color = c;
            yield return new WaitForSeconds(1f/fadeAwaySpeed);
        }

        Destroy(gameObject);
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
