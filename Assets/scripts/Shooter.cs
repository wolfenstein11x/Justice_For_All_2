using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Bullet bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootRange;
    [SerializeField] LayerMask shootRaycastLayers;

    private MuzzleFlash muzzleFlash;
    private AudioSource gunSound;
    private OrientationTracker orientationTracker;

    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash = GetComponentInChildren<MuzzleFlash>();
        gunSound = GetComponentInChildren<AudioSource>();
        orientationTracker = GetComponent<OrientationTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        gunSound.Play();
        muzzleFlash.Fire();
        Bullet firedBullet = Instantiate(bullet, shootPoint.position, bullet.transform.rotation);
        firedBullet.transform.parent = gameObject.transform;
    }

    public bool InShootingRange()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, Vector2.right * new Vector2(orientation, 0f), shootRange, shootRaycastLayers);

        // ray hit something, could be a wall or a target
        if (hit.collider != null)
        {
            // ray hit a target, because only a target would have Health
            if (hit.collider.gameObject.GetComponent<Health>() != null)
            {
                Debug.DrawRay(shootPoint.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
                return true;
            }

            // ray hit a wall
            else
            {
                Debug.DrawRay(shootPoint.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.yellow);
                return false;
            }
            
        }

        // ray hit nothing
        else
        {
            Debug.DrawRay(shootPoint.position, Vector2.right * shootRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }
}
