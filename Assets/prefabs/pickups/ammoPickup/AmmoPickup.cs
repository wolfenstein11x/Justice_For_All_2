using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] string ammoOrGrenades;
    [SerializeField] int ammoAmount;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] float pickupSoundDuration = 0.25f;

    SpriteRenderer spriteRenderer;
    GameObject ammoType;

    bool obtained;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obtained = false;

        ammoType = GameObject.FindWithTag(ammoOrGrenades);

        // de-child from parent crate, so that when crate is destroyed, ammo inside won't be destroyed
        transform.parent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // prevent double pickup in case of double collision
        if (obtained) return;


        obtained = true;

        pickupSound.Play();

        ammoType.GetComponent<AmmoTracker>().CollectAmmo(ammoAmount);

        // after picking up item, make it disappear, but don't destroy yet until sound finished playing
        spriteRenderer.enabled = false;

        // destroy invisible game object after sound finished playing
        Destroy(gameObject, pickupSoundDuration);
    }
}
