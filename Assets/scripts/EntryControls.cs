using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryControls : MonoBehaviour
{
    // 0 is enter, 1 is exit, 2 is unlock
    [SerializeField] GameObject[] entryButtons;
    [SerializeField] AudioSource unlockSound;
    [SerializeField] AudioSource enterExitSound;

    Building linkedBuilding;
    PlayerController pc;
    

    // Start is called before the first frame update
    void Start()
    {
        HideAllButtons();
        pc = FindObjectOfType<PlayerController>();
    }

    public void HideAllButtons()
    {
        foreach(GameObject entryButton in entryButtons)
        {
            entryButton.SetActive(false);
        }
    }

    public void RevealButton(int buttonIdx)
    {
        HideAllButtons();
        entryButtons[buttonIdx].SetActive(true);
    }

    public void LinkToBuilding(Building building)
    {
        linkedBuilding = building;
    }

    public void EnterButton()
    {
        linkedBuilding.EnterBuilding();
        enterExitSound.Play();
        HideAllButtons();
    }

    public void ExitButton()
    {
        linkedBuilding.ExitBuilding();
        enterExitSound.Play();
        HideAllButtons();
    }

    public void UnlockButton()
    {
        //Debug.Log("unlock!");
        pc.UseKey();
        unlockSound.Play();
        linkedBuilding.LockUnlockBuilding(false);
        HideAllButtons();
    }
}
