using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int activeSceneIdx;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        activeSceneIdx = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(activeSceneIdx);
    }

    public void LoadNextLevel()
    {
        if (activeSceneIdx >= 47)
        {
            LoadMainMenu();
        }

        else
        {
            SceneManager.LoadScene(activeSceneIdx + 1);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
