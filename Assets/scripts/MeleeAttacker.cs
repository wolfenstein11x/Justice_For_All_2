using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{

    [SerializeField] float meleeRange = 1f;
    [SerializeField] Transform meleePos;
    [SerializeField] float meleeDamage;
    [SerializeField] LayerMask meleeRaycastLayers;
    [SerializeField] AudioSource meleeSwingSound;

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
            //Debug.DrawRay(meleePos.position, Vector2.right * hitMelee.distance * new Vector2(orientation, 0f), Color.red);
            return true;
        }
        else
        {
            //Debug.DrawRay(meleePos.position, Vector2.right * meleeRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }

    }

    public void AttemptDealMeleeDamage()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.right * new Vector2(orientation, 0f), meleeRange, meleeRaycastLayers);

        if (hitMelee.collider != null)
        {
            Health targetHealth = hitMelee.collider.gameObject.GetComponent<Health>();

            // added this to eliminate occasional null reference error
            if (targetHealth == null) return;

            targetHealth.PlayMeleeDamageSound();
            targetHealth.TakeDamage(meleeDamage);
        }

    }

    public void PlayMeleeSwingSound()
    {
        if (!InMeleeRange())
        {
            meleeSwingSound.Play();
        }
    }

    
}
