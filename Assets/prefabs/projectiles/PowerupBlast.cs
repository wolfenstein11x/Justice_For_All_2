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
        sr = GetComponentInChildren<SpriteRenderer>();
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
            FadeAway();
        }

        // hit wall, blow up
        else
        {
            FadeAway();
        }

    
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
            yield return new WaitForSeconds(0.025f);
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
