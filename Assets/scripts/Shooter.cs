using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] protected AudioSource gunSound;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] Transform muzzleFlashPoint;
    [SerializeField] Transform shootPointCrouching;
    [SerializeField] Transform muzzleFlashPointCrouching;
    [SerializeField] protected float shootRange;
    [SerializeField] protected LayerMask shootRaycastLayers;

    protected OrientationTracker orientationTracker;


    // Start is called before the first frame update
    void Start()
    {
        orientationTracker = GetComponent<OrientationTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot()
    {
        gunSound.Play();
        GameObject gunMuzzleFlash = Instantiate(muzzleFlash, muzzleFlashPoint.position, muzzleFlash.transform.rotation);
        gunMuzzleFlash.transform.localScale = new Vector2(1.0f * orientationTracker.GetOrientation(), 1f);
        Bullet firedBullet = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
        firedBullet.transform.parent = gameObject.transform;
    }

    public void ShootCrouched()
    {
        gunSound.Play();
        GameObject gunMuzzleFlash = Instantiate(muzzleFlash, muzzleFlashPointCrouching.position, muzzleFlash.transform.rotation);
        gunMuzzleFlash.transform.localScale = new Vector2(1.0f * orientationTracker.GetOrientation(), 1f);
        Bullet firedBullet = Instantiate(bullet, shootPointCrouching.position, bullet.transform.rotation);
        firedBullet.transform.parent = gameObject.transform;
    }

    public virtual bool InShootingRange()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.right * new Vector2(orientation, 0f), shootRange, shootRaycastLayers);

        // ray hit something, could be a wall or a target
        if (hit.collider != null)
        {
            // ray hit a target, because only a target would have Health
            if (hit.collider.gameObject.GetComponent<Health>() != null)
            {
                //Debug.DrawRay(shootPoint.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
                return true;
            }

            // ray hit a wall
            else
            {
                //Debug.DrawRay(shootPoint.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.yellow);
                return false;
            }
            
        }

        // ray hit nothing
        else
        {
            //Debug.DrawRay(shootPoint.position, Vector2.right * shootRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }
}
