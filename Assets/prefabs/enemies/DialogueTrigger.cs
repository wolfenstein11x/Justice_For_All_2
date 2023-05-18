using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    PlayerController pc;

    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] GameObject joystick, weaponButtons;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.SetActive(false);
        pc = FindObjectOfType<PlayerController>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            pc.SetDialogueMode(true);

            dialogueCanvas.SetActive(true);
            joystick.SetActive(false);
            weaponButtons.SetActive(false);
        }
    }
}
