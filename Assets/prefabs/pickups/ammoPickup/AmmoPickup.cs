using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] GameObject ammoType;
    [SerializeField] int ammoAmount;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] float pickupSoundDuration = 0.25f;

    SpriteRenderer spriteRenderer;

    bool obtained;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obtained = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // prevent double pickup in case of double collision
        if (obtained) return;


        obtained = true;

        pickupSound.Play();

        Debug.Log("got me some ammo");

        // after picking up item, make it disappear, but don't destroy yet until sound finished playing
        spriteRenderer.enabled = false;

        // destroy invisible game object after sound finished playing
        Destroy(gameObject, pickupSoundDuration);
    }
}
