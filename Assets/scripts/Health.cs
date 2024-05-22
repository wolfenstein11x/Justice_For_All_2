using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hitPoints = 20f;
    [SerializeField] protected AudioSource meleeDamageSound;

    protected Animator animator;
    protected SpriteRenderer sr;
    protected CapsuleCollider2D capsuleCollider;
    protected float startingHitPoints;
 

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        startingHitPoints = hitPoints;
    }

    
    public void Revive()
    {
        hitPoints = startingHitPoints;
        capsuleCollider.enabled = true;
    }

  

    public virtual void TakeDamage(float damage)
    {
        if (hitPoints <= 0) return;

        animator.SetBool("isProvoked", true);

        hitPoints -= damage;
        PlayDamageEffect();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void PlayMeleeDamageSound()
    {
        meleeDamageSound.Play();
    }

    protected virtual void Die()
    {
        animator.SetTrigger("die");

        // turn off collider so that dead enemy doesn't block attacks
        if (capsuleCollider != null) capsuleCollider.enabled = false;
    }

    public void ForceDie()
    {
        if (hitPoints > 0)
        {
            hitPoints = 0f;
            Die();
        }
        
    }

    protected void PlayDamageEffect()
    {
        StartCoroutine(FlickerSprite(10));
    }

    // parameter flickerRate must be even number
    IEnumerator FlickerSprite(int flickerRate)
    {
        Color c = sr.material.color;

        float alpha = 1f;

        for (int i=0; i < flickerRate; i++)
        {
            alpha = (i % 2 == 0) ? 0.5f : 1f;
            c.a = alpha;
            sr.material.color = c;
            yield return new WaitForSeconds(1.0f / flickerRate);
        }

    }

    
}
