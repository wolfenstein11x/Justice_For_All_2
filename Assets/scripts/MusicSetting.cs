using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSetting : MonoBehaviour
{
    Song song;

    // Start is called before the first frame update
    void Start()
    {
        song = FindObjectOfType<Song>();
    }

    public void TurnMusicOn()
    {
        PlayerPrefs.SetInt("musicOn", 1);
        PlayerPrefs.Save();
        song.SetMusic(true);
    }

    public void TurnMusicOff()
    {
        PlayerPrefs.SetInt("musicOn", 0);
        PlayerPrefs.Save();
        song.SetMusic(false);
    }
}
