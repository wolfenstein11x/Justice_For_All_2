using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] int sceneIdx;
    [SerializeField] GameObject lockIcon, numberIcon;

    private bool locked;

    private void Awake()
    {
        LockSelf();
    }

    public void LockSelf()
    {
        locked = true;
        numberIcon.SetActive(false);
        lockIcon.SetActive(true);
    }

    public void UnlockSelf()
    {
        locked = false;
        numberIcon.SetActive(true);
        lockIcon.SetActive(false);
    }

    public void ButtonPress()
    {
        if (locked) return;

        FindObjectOfType<MainMenuController>().LoadLevelButton(sceneIdx);
    }


}
