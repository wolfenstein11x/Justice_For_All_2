using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] HealthBarHealth[] mainEnemies;
    [SerializeField] EnemyInstaniator[] enemyInstantiators;
    [SerializeField] float countEnemiesDelay = 2f;

    MenuController mc;

    private int mainEnemyDeathCount;

    private void Start()
    {
        mainEnemyDeathCount = 0;
        mc = FindObjectOfType<MenuController>();
    }

    private bool MainEnemiesDead()
    {
        return mainEnemyDeathCount >= mainEnemies.Length;
    }

    private bool RegularEnemiesDead()
    {
        bool allDead = true;

        foreach (EnemyInstaniator enemyInstaniator in enemyInstantiators)
        {
            if (enemyInstaniator.HasEnemies())
            {
                //Debug.Log(enemyInstaniator.name + " has enemies"); 
                allDead = false;
            }
        }

        return allDead;
    }

    public void ProcessMainEnemyDeath()
    {
        mainEnemyDeathCount++;

        //Debug.Log("Main enemies death count: " + mainEnemyDeathCount);
        if (MainEnemiesDead())
        {
            foreach (EnemyInstaniator enemyInstantiator in enemyInstantiators)
            {
                enemyInstantiator.Terminate();
            }
        }
    }

    public void CheckLevelComplete()
    {
        Invoke(nameof(CheckEnemiesDead), countEnemiesDelay);
    }

    private void CheckEnemiesDead()
    {
        if (MainEnemiesDead() && RegularEnemiesDead())
        {
            //Debug.Log("level complete");
            mc.ActivateLevelCompleteMenu();
        }
    }
}
