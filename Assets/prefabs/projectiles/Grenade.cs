using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float initialVelocityX = 5f;
    [SerializeField] float initialVelocityY = 5f;
    [SerializeField] float explosionDelayMin = 4f;
    [SerializeField] float explosionDelayMax = 5f;
    [SerializeField] float explosionDuration = 0.5f;
    [SerializeField] GameObject explosion;
    [SerializeField] float explosionOffsetX = 0.42f;
    [SerializeField] float explosionOffsetY = 2.04f;
    [SerializeField] float explosionRadius = 5f;
    //[SerializeField] float explosionForceX = 5f;
    //[SerializeField] float explosionForceY = 20f;

    Rigidbody2D grenadeRigidbody;
    float orientation;
    AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        orientation = GetComponentInParent<OrientationTracker>().GetOrientation();
        grenadeRigidbody = GetComponent<Rigidbody2D>();
        grenadeRigidbody.velocity = new Vector2(initialVelocityX * orientation, initialVelocityY);
        //explosionSound = GetComponent<AudioSource>();

        // de-child grenade from thrower so it does not move with thrower
        transform.parent = null;

        float explosionDelay = Random.Range(explosionDelayMin, explosionDelayMax);
        //StartCoroutine(ExplodeCoroutine(explosionDelay));
    }

    
}
