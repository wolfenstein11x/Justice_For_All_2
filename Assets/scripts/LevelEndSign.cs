using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndSign : MonoBehaviour
{
    MenuController menuController;

    // Start is called before the first frame update
    void Start()
    {
        menuController = FindObjectOfType<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            menuController.ActivateLevelCompleteMenu();
            GetComponent<SavePoint>().UnlockLevel();
        }
    }
}
