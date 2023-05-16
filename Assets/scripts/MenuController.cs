using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject levelCompleteMenu;

    SceneLoader sceneLoader;

    private void Awake()
    {
        gameOverMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HomeButton()
    {

    }

    public void PlayAgainButton()
    {
        sceneLoader.ReloadLevel();
    }

    public void NextLevelButton()
    {
        sceneLoader.LoadNextLevel();
    }

    public void ActivateGemOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void ActivateLevelCompleteMenu()
    {
        levelCompleteMenu.SetActive(true);
    }
}
