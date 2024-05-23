using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    [SerializeField] Key key;

    SavePoint savePoint;
    MusicController musicController;

    private void Awake()
    {
        key.gameObject.SetActive(false);
        savePoint = GetComponent<SavePoint>();
        musicController = FindObjectOfType<MusicController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ProcessDeath()
    {
        key.gameObject.SetActive(true);
        musicController.PlaySong(0);
    }
}
