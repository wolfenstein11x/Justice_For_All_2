using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject LevelsMenu1, LevelsMenu2, LevelsMenu3, PlayMenu, SettingsMenu;
    [SerializeField] GameObject loadingText;

    // Start is called before the first frame update
    void Start()
    {
        PlayMenu.SetActive(true);
        LevelsMenu1.SetActive(false);
        LevelsMenu2.SetActive(false);
        LevelsMenu3.SetActive(false);
        SettingsMenu.SetActive(false);
        loadingText.SetActive(false);
    }

    public void LoadLevelButton(int level)
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene(level);
    }

    public void PlayButton()
    {
        PlayMenu.SetActive(false);
        LevelsMenu1.SetActive(true);
    }

    public void SettingsButton()
    {
        PlayMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void NextPageButton1()
    {
        LevelsMenu1.SetActive(false);
        LevelsMenu2.SetActive(true);
    }

    public void NextPageButton2()
    {
        LevelsMenu2.SetActive(false);
        LevelsMenu3.SetActive(true);
    }

    public void PrevPageButton1()
    {
        LevelsMenu1.SetActive(true);
        LevelsMenu2.SetActive(false);
    }

    public void PrevPageButton2()
    {
        LevelsMenu2.SetActive(true);
        LevelsMenu3.SetActive(false);
    }

    public void LevelsMenu1CloseButton()
    {
        LevelsMenu1.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void LevelsMenu2CloseButton()
    {
        LevelsMenu2.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void LevelsMenu3CloseButton()
    {
        LevelsMenu3.SetActive(false);
        PlayMenu.SetActive(true);
    }

    public void SettingsMenuCloseButton()
    {
        SettingsMenu.SetActive(false);
        PlayMenu.SetActive(true);
    }

}

    
