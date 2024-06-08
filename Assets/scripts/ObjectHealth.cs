using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : Health
{
    [SerializeField] AudioSource breakSound;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();        
    }

    public override void TakeDamage(float damage)
    {
        if (hitPoints <= 0) return;
        
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }
    
    protected override void Die()
    {
        breakSound.Play();
        animator.SetBool("isBroken", true);
        capsuleCollider.enabled = false;

        
        
    }

    public void RemoveFromPlay()
    {
        Destroy(gameObject);
    }


}
