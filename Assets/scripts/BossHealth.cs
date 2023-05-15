using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : PlayerHealth
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(hitPoints);
    }

    protected override void Die()
    {
        animator.SetTrigger("die");
    }
}
