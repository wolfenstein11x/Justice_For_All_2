using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] float startingHitpointsEasy, startingHitpointsMedium, startingHitpointsHard;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();    
    }

    protected override void Initialize()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        InitHitPoints();

        hitPoints = startingHitPoints;
        healthBar.SetMaxHealth(hitPoints);
    }

    private void InitHitPoints()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);
        
        switch (difficulty)
        {
            case 0:
                startingHitPoints = startingHitpointsEasy;
                break;
            case 1:
                startingHitPoints = startingHitpointsMedium;
                break;
            case 2:
                startingHitPoints = startingHitpointsHard;
                break;
            default:
                startingHitPoints = startingHitpointsMedium;
                break;
        }
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

    public float GetMaxHealth()
    {
        return healthBar.GetMaxHealth();
    }
}
