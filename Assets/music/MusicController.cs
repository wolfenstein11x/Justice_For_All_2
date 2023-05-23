using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource regularMusic;
    [SerializeField] AudioSource bossMusic;
    [SerializeField] AudioSource indoorMusic; 


    // Start is called before the first frame update
    void Start()
    {
        PlaySong(0);
    }

    public void PlaySong(int selection)
    {
        switch (selection)
        {
            case 0:
                regularMusic.Play();
                bossMusic.Stop();
                indoorMusic.Stop();
                break;
            case 1:
                regularMusic.Stop();
                bossMusic.Play();
                indoorMusic.Stop();
                break;
            case 2:
                regularMusic.Stop();
                bossMusic.Stop();
                indoorMusic.Play();
                break;
        }
    }
}
