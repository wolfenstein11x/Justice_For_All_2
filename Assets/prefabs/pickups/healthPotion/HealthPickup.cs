using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float healPercentage = 0;
    [SerializeField] AudioSource healSound;
    [SerializeField] float healSoundDuration = 0.25f;

    SpriteRenderer spriteRenderer;

    bool obtained;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        obtained = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // prevent double healing in case of double collision
        if (obtained) return;

        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        float maxHealth = playerHealth.GetMaxHealth();
        float healAmount = maxHealth * healPercentage;

        if (playerHealth != null)
        {
            obtained = true;

            playerHealth.Heal(healAmount);
            healSound.Play();

            // after picking up item, make it disappear, but don't destroy yet until sound finished playing
            spriteRenderer.enabled = false;

            // destroy invisible game object after sound finished playing
            Destroy(gameObject, healSoundDuration);
        }
    }


    
    
}
