using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{

    [SerializeField] float meleeRange = 1f;
    [SerializeField] Transform meleePos;
    [SerializeField] float meleeDamage;
    [SerializeField] LayerMask meleeRaycastLayers;

    Rigidbody2D rb;
    OrientationTracker orientationTracker;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        orientationTracker = GetComponent<OrientationTracker>();
    }

    public bool InMeleeRange()
    {
        float orientation = orientationTracker.GetOrientation();

        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);


        if (hitMelee.collider != null)
        {
            Debug.DrawRay(meleePos.position, Vector2.right * hitMelee.distance * new Vector2(orientation, 0f), Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(meleePos.position, Vector2.right * meleeRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }

    public void AttemptDealMeleeDamage()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        if (hitMelee.collider.gameObject.GetComponent<Health>() != null)
        {
            Health targetHealth = hitMelee.collider.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(meleeDamage);
        }
    }
}
