using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] LevelButton[] levelButtons;

    private int highestUnlockedLevel;

    // Start is called before the first frame update
    void Start()
    {
        highestUnlockedLevel = PlayerPrefs.GetInt("highestUnlockedLevel", 1);

        UnlockLevels(highestUnlockedLevel);
    }

    private void UnlockLevel(int levelButtonIdx)
    {
        levelButtons[levelButtonIdx].UnlockSelf();
    }

    private void UnlockLevels(int highestLevel)
    {
        for (int i=0; i < highestUnlockedLevel; i++)
        {
            UnlockLevel(i);
        }
    }
}
