using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Respawner[] respawners;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        foreach(Respawner respawner in respawners)
        {
            respawner.Spawn();
        }
    }

    private void OnDisable()
    {
        foreach(Respawner respawner in respawners)
        {
            respawner.Deactivate();
        }
    }
}
