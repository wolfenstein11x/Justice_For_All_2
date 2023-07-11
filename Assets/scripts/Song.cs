using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] float maxVolume; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int musicOn = PlayerPrefs.GetInt("musicOn", 1);

        if (musicOn == 1)
        {
            SetMusic(true);
        }

        else
        {
            SetMusic(false);
        }
    }

    public void SetMusic(bool status)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (status == true)
        {
            audioSource.volume = maxVolume;
        }

        else
        {
            audioSource.volume = 0f;
        }

    }
}
