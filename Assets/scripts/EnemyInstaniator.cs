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
    private bool terminated;
    float zedPos = 0f;

    private void Start()
    {
        allowInvoke = true;
        terminated = false;
    }

    private void Update()
    {
        if (MaxEnemies() || terminated) return;

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
        return transform.childCount >= maxEnemies;
    }

    public bool HasEnemies()
    {
        //Debug.Log(gameObject.name + ": " + transform.childCount);
        return transform.childCount > 0;
    }

    public void Terminate()
    {
        terminated = true;
    }
}
