using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    public int highestUnlockedLevel = 1;
    [SerializeField] LevelButton[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
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
