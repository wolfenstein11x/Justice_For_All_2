using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float hitPoints = 20f;
    [SerializeField] AudioSource takeDamageSound;

    protected Animator animator;
    protected SpriteRenderer renderer;
 

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        if (hitPoints <= 0) return;

        hitPoints -= damage;
        takeDamageSound.Play();
        PlayDamageEffect();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
    }

    private void PlayDamageEffect()
    {
        StartCoroutine(FlickerSprite(10));
    }

    // parameter flickerRate must be even number
    IEnumerator FlickerSprite(int flickerRate)
    {
        Color c = renderer.material.color;

        float alpha = 1f;

        for (int i=0; i < flickerRate; i++)
        {
            alpha = (i % 2 == 0) ? 0.5f : 1f;
            c.a = alpha;
            renderer.material.color = c;
            yield return new WaitForSeconds(1.0f / flickerRate);
        }

    }
}
