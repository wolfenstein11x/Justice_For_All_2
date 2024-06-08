using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstaniator : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    [SerializeField] float maxEnemies = 5;
    [SerializeField] float delayMin = 3f;
    [SerializeField] float delayMax = 6f;

    private bool allowInvoke;

    private void Start()
    {
        allowInvoke = true;
    }

    private void Update()
    {
        if (MaxEnemies()) return;

        if (allowInvoke)
        {
            Invoke(nameof(InstantiateRandomEnemy), GenDelay());
            allowInvoke = false;
        }
    }

    private void InstantiateRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);

        Enemy instantiatedEnemy = Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
        instantiatedEnemy.transform.parent = gameObject.transform;

        allowInvoke = true;
    }

    private float GenDelay()
    {
        return Random.Range(delayMin, delayMax);
    }

    private bool MaxEnemies()
    {
        int enemyCount = GetComponentsInChildren<Enemy>().Length;
        return (enemyCount >= maxEnemies);
    }
}
