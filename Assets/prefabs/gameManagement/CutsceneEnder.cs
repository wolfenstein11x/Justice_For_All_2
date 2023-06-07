using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnder : MonoBehaviour
{
    SceneLoader sceneLoader;

    private void OnEnable()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadNextLevel();
    }
}
