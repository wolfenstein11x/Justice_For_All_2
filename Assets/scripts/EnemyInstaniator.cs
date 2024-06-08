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
    float zedPos = 0f;

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

        Vector3 instantiatePos = new Vector3(transform.position.x, transform.position.y, zedPos);
        Enemy instantiatedEnemy = Instantiate(enemies[enemyIndex], instantiatePos, transform.rotation);
        instantiatedEnemy.transform.parent = gameObject.transform;

        // prevent zed fighting
        zedPos += 1.0f;

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
