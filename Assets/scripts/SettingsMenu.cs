using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] CheckBox easyBox, mediumBox, hardBox;
    [SerializeField] CheckBox onBox, offBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty", 1);
        int musicOn = PlayerPrefs.GetInt("musicOn", 1);

        switch(difficulty)
        {
            case 0:
                easyBox.CheckSelf();
                break;
            case 1:
                mediumBox.CheckSelf();
                break;
            case 2:
                hardBox.CheckSelf();
                break;
            default:
                mediumBox.CheckSelf();
                break;
        }

        switch (musicOn)
        {
            case 0:
                offBox.CheckSelf();
                break;
            case 1:
                onBox.CheckSelf();
                break;
            default:
                onBox.CheckSelf();
                break;
        
        }

    }
}
