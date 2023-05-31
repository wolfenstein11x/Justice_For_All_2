using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy enemySpawn;
    [SerializeField] Transform spawnPoint;

    

    public void Spawn()
    {
        Enemy enemySpawnInstance = Instantiate(enemySpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
