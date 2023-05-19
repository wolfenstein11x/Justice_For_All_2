using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : PlayerHealth
{
    Boss boss;

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
        boss = GetComponent<Boss>();
    }

    protected override void Die()
    {
        animator.SetTrigger("die");
        boss.StartPostBattleDialogue();
        
    }
}
