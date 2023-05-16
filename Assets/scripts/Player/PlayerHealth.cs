using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
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
        if (hitPoints <= 0) return;

        hitPoints -= damage;
        PlayDamageEffect();

        if (hitPoints <= 0)
        {
            Die();
        }

        healthBar.SetHealth(hitPoints);
    }

    protected override void Die()
    {
        base.Die();
        FindObjectOfType<MenuController>().ActivateGemOverMenu();
    }

    public bool IsDead()
    {
        return hitPoints <= 0;
    }

    public void Heal(float healAmount)
    {
        float maxHealth = healthBar.GetMaxHealth();

        if ((hitPoints + healAmount) > healthBar.GetMaxHealth())
        {
            hitPoints = maxHealth;
        }

        else
        {
            hitPoints = (hitPoints + healAmount);
        }

        healthBar.SetHealth(hitPoints);
    }
}
