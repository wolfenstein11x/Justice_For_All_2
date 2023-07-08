using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject levelCompleteMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] controlPanels;

    SceneLoader sceneLoader;

    private void Awake()
    {
        Time.timeScale = 1;

        gameOverMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);
        pauseMenu.SetActive(false);

        ShowControlsPanels(true);
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
        sceneLoader.LoadMainMenu();
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

    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        ShowControlsPanels(false);
        Time.timeScale = 0;
    }

    public void UnpauseButton()
    {
        pauseMenu.SetActive(false);
        ShowControlsPanels(true);
        Time.timeScale = 1;
    }

    void ShowControlsPanels(bool status)
    {
        foreach (GameObject controlPanel in controlPanels)
        {
            controlPanel.SetActive(status);
        }
    }
}
