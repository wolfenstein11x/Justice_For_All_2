using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrooms : MonoBehaviour
{
    [SerializeField] GameObject[] itemsToActivate;
    [SerializeField] GameObject[] itemsToDeactivate;
    [SerializeField] AudioSource pickupSound;
    [SerializeField] float pickupSoundDuration = 0.25f;

    SpriteRenderer spriteRenderer;
    bool obtained;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        obtained = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // prevent double pickup in case of double collision
        if (obtained) return;

        obtained = true;

        //pickupSound.Play();

        foreach (GameObject item in itemsToActivate)
        {
            item.SetActive(true);
        }

        foreach (GameObject item in itemsToDeactivate)
        {
            item.SetActive(false);
        }

        // after picking up item, make it disappear, but don't destroy yet until sound finished playing
        spriteRenderer.enabled = false;

        // destroy invisible game object after sound finished playing
        Destroy(gameObject, pickupSoundDuration);
    }


}
