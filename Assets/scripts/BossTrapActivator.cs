using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrapActivator : MonoBehaviour
{
    [SerializeField] GameObject[] bossTraps;

    BossHealth bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        DisableAllBossTraps();
    }

    public void ActivateBossTrap(int trapIdx)
    {
        // ignore trap activation if there is no trap to activate
        if (trapIdx >= bossTraps.Length) return;

        bossTraps[trapIdx].SetActive(true);
    }


    public void DisableAllBossTraps()
    {
        foreach(GameObject bossTrap in bossTraps)
        {
            bossTrap.SetActive(false);
        }
    }
}
