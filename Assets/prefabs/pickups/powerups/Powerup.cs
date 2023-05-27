using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{
    [SerializeField] string powerupTag;
    [SerializeField] AudioSource powerupSound;
    [SerializeField] float healSoundDuration = 0.25f;

    SpriteRenderer spriteRenderer;
    GameObject powerupButton;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        powerupButton = GameObject.FindWithTag(powerupTag);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // prevent double healing in case of double collision


        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

        if (pc != null)
        {
            powerupButton.GetComponent<PowerupButton>().SetButtonActive(true);

            powerupSound.Play();

            // after picking up item, make it disappear, but don't destroy yet until sound finished playing
            spriteRenderer.enabled = false;

            // destroy invisible game object after sound finished playing
            Destroy(gameObject, healSoundDuration);
        }
    }
}
