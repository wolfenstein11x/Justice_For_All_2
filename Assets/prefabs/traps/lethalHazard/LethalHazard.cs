using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalHazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(health.hitPoints);
        }
    }
}
