using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int activeSceneIdx;

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
        SceneManager.LoadScene(activeSceneIdx + 1);
    }
}
