using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySetting : MonoBehaviour
{
    [SerializeField] int difficulty;


    public void SetDifficulty()
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
        PlayerPrefs.Save();
    }
}
