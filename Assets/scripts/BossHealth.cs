using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : HealthBarHealth
{
    Boss boss;
    bool invincibleMode;
    //[SerializeField] float healthThreshold1, healthThreshold2;

    //Boss boss;
    //BossTrapActivator bossTrapActivator;
    //bool reachedThreshold1 = false;
    //bool reachedThreshold2 = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
        boss = GetComponent<Boss>();
    }

    /*
    private void Update()
    {
        
        if (hitPoints <= healthThreshold2)
        {
            if (reachedThreshold2) return;
            reachedThreshold2 = true;
            if (bossTrapActivator != null) bossTrapActivator.ActivateBossTrap(1);
        }

        else if (hitPoints <= healthThreshold1)
        {
            if (reachedThreshold1) return;
            reachedThreshold1 = true;
            if (bossTrapActivator != null) bossTrapActivator.ActivateBossTrap(0);
        }
        
    }*/

    public override void TakeDamage(float damage)
    {
        if (invincibleMode) return;

        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        animator.SetTrigger("die");
        boss.ProcessDeath();
        FindObjectOfType<MusicController>().PlaySong(0);
        
    }

    public void SetInvincibleMode(bool status)
    {
        invincibleMode = status;
    }
}
