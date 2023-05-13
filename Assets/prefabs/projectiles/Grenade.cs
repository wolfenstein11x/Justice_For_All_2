using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float maxDamage = 10f;
    [SerializeField] float initialVelocityX = 5f;
    [SerializeField] float initialVelocityY = 5f;
    [SerializeField] float explosionDelayMin = 4f;
    [SerializeField] float explosionDelayMax = 5f;
    [SerializeField] float explosionDuration = 0.5f;
    [SerializeField] VFX explosion;
    [SerializeField] AudioSource explosionSound;
    [SerializeField] float explosionOffsetX = 0.42f;
    [SerializeField] float explosionOffsetY = 2.04f;
    [SerializeField] float explosionRadius = 5f;
    //[SerializeField] float explosionForceX = 5f;
    //[SerializeField] float explosionForceY = 20f;

    Rigidbody2D grenadeRigidbody;
    float orientation;

    // Start is called before the first frame update
    void Start()
    {
        orientation = GetComponentInParent<OrientationTracker>().GetOrientation();
        grenadeRigidbody = GetComponent<Rigidbody2D>();
        grenadeRigidbody.velocity = new Vector2(initialVelocityX * orientation, initialVelocityY);

        // de-child grenade from thrower so it does not move with thrower
        transform.parent = null;

        float explosionDelay = Random.Range(explosionDelayMin, explosionDelayMax);
        StartCoroutine(ExplodeCoroutine(explosionDelay));
    }

    IEnumerator ExplodeCoroutine(float explosionDelay)
    {
        yield return new WaitForSeconds(explosionDelay);

        // make grenade disappear
        GetComponent<SpriteRenderer>().enabled = false;

        // show explosion in place of grenade and play sound
        explosionSound.Play();
        Vector3 explosionPoint = new Vector3(transform.position.x + explosionOffsetX, transform.position.y + explosionOffsetY, transform.position.z);
        VFX grenadeExplosion = Instantiate(explosion, explosionPoint, explosion.transform.rotation);

        // impact force on any player or enemy within radius
        DealExplosionDamage();

        // remove grenade when sound is finished playing (explosion is a VFX so it destroys itself when finished with its animation, no need to destroy it here)
        Destroy(gameObject, explosionDuration);

    }

    private void DealExplosionDamage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        //Debug.Log("explosion position: (" + transform.position.x + "," + transform.position.y + ")");
        foreach (Collider2D collider in colliders)
        {
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


}
