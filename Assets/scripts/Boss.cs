using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    [SerializeField] Key key;
    [SerializeField] EnemyInstaniator enemyInstantiator;

    MusicController musicController;

    private void Awake()
    {
        key.gameObject.SetActive(false);
        musicController = FindObjectOfType<MusicController>();
    }

   
    public void ProcessDeath()
    {
        enemyInstantiator.Terminate();
        key.gameObject.SetActive(true);
        musicController.PlaySong(0);
    }
}
