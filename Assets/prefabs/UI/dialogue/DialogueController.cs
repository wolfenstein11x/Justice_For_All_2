using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    PlayerController pc;

    [SerializeField] bool preBossBattle;
    [SerializeField] bool postBossBattle;
    [SerializeField] bool preArrest;
    [SerializeField] Boss boss;
    [SerializeField] HealthBar bossHealthBar;
    [SerializeField] GameObject dialogueTemplate;
    [SerializeField] Dialogue dialogue;
    [SerializeField] DialogueTrigger dialogueTrigger;
    [SerializeField] GameObject joystick, weaponButtons;
    [SerializeField] float startDialogueDelay = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        if (preBossBattle || postBossBattle)
        {
            bossHealthBar.gameObject.SetActive(false);
        }

        dialogueTemplate.SetActive(false);
        pc = FindObjectOfType<PlayerController>();
    }

    public void StartDialogue()
    {
        pc.SetDialogueMode(true);
            //Debug.Log("started dialogue");
        dialogueTemplate.SetActive(true);
        joystick.SetActive(false);
        weaponButtons.SetActive(false);

        // give short delay before typing line to give Dialogue game object enough time to initialize, preventing null reference error
        Invoke(nameof(TypeLine), startDialogueDelay);
    }

    void TypeLine()
    {
        dialogue.TypeNextLine();
    }

    public void ConcludeDialogue()
    {
        //Debug.Log("concluding dialogue");
        if (preBossBattle)
        {
            pc.SetDialogueMode(false);
            boss.SetDialogueMode(false);

            bossHealthBar.gameObject.SetActive(true);
            dialogueTemplate.SetActive(false);
            joystick.SetActive(true);
            weaponButtons.SetActive(true);

        }

        else if (postBossBattle)
        {
            pc.SetDialogueMode(false);

            bossHealthBar.gameObject.SetActive(false);
            dialogueTemplate.SetActive(false);
            joystick.SetActive(true);
            weaponButtons.SetActive(true);
        }

        dialogueTrigger.gameObject.SetActive(false);
    }
}