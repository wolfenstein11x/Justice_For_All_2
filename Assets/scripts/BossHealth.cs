using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : HealthBarHealth
{
    //[SerializeField] float healthThreshold1, healthThreshold2;

    //Boss boss;
    //BossTrapActivator bossTrapActivator;
    //bool reachedThreshold1 = false;
    //bool reachedThreshold2 = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    private void Update()
    {
        /*
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
        */
    }

    

    protected override void Die()
    {
        animator.SetTrigger("die");
        Debug.Log("reveal key");
        FindObjectOfType<MusicController>().PlaySong(0);
        
    }
}
