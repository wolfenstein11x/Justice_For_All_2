using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstaniator : MonoBehaviour
{
    [SerializeField] Enemy enemy;
   
    private void OnEnable()
    {
        Enemy instantiatedEnemy = Instantiate(enemy, transform.position, transform.rotation);
        instantiatedEnemy.transform.parent = gameObject.transform;
    }
}
