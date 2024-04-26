using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarHealth : Health
{
    [SerializeField] protected HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();

        healthBar.SetMaxHealth(hitPoints);
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        healthBar.SetHealth(hitPoints);
    }

    
}
