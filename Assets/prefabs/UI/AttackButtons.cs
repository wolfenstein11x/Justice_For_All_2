using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButtons : MonoBehaviour
{
    [SerializeField] GameObject[] shootButtons;
    
    void Start()
    {
        ActivateShootButton(0);
    }

    // 0 is regular gun, 1 is green blast, 2 is blue blast, 3 is purple blast
    public void ActivateShootButton(int shootButtonIdx)
    {
        foreach(GameObject shootButton in shootButtons)
        {
            shootButton.SetActive(false);
        }

        shootButtons[shootButtonIdx].SetActive(true);
    }

    
}
