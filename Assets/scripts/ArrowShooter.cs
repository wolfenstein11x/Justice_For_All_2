using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : Shooter
{
    [SerializeField] AudioSource boltSound;
    [SerializeField] AudioSource shootSound;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        orientationTracker = GetComponent<OrientationTracker>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InShootingRange())
        {
            animator.SetBool("shootMode", true);
        }

        else
        {
            animator.SetBool("shootMode", false);
        }
    }

    public override void Shoot()
    {
        Bullet firedBullet = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
        firedBullet.transform.parent = gameObject.transform;
    }

    public void PlayBoltSound()
    {
        boltSound.Play();
    }

    public void PlayShootSound()
    {
        shootSound.Play();
    }

    
}
