using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBarrel : MonoBehaviour
{
    [SerializeField] float maxDamage;
    [SerializeField] float explosionRadius;
    [SerializeField] VFX explosion;
    [SerializeField] Transform explosionPos;
    [SerializeField] float explosionDuration;
    [SerializeField] AudioSource explosionSound;
    [SerializeField] float explosionSoundDuration;

    Animator animator;
    bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploded) return;
        exploded = true;

        animator.SetBool("exploded", true);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        //Debug.Log("explosion position: (" + transform.position.x + "," + transform.position.y + ")");
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "boss") continue;

            Health targetHealth = collider.GetComponent<Health>();

            if (targetHealth != null)
            {
                float distanceToExplosion = Vector2.Distance(transform.position, collider.transform.position);

                // saturate closest distance at 1 unit, so grenade doesn't exceed max damage
                if (distanceToExplosion < 1f) distanceToExplosion = 1f;

                // the closer one is to explosion, the higher the damage
                float explosionDamage = maxDamage / distanceToExplosion;

                //Debug.Log(explosionDamage + " damage at distance of " + distanceToExplosion);

                targetHealth.TakeDamage(explosionDamage);
            }
        }

    }

    public void Explode()
    {
        AudioSource explosionSoundInstance = Instantiate(explosionSound, transform.position, transform.rotation);
        VFX explosionInstance = Instantiate(explosion, explosionPos.position, transform.rotation);

        Destroy(explosionSoundInstance, explosionSoundDuration);
        Destroy(explosionInstance, explosionDuration);
        Destroy(gameObject, explosionDuration);
    }
}
