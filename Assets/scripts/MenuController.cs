using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;

    private void Awake()
    {
        gameOverMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
        FindObjectOfType<SceneLoader>().ReloadLevel();
    }

    public void ActivateGemOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
