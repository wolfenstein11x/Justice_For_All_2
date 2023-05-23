using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] DialogueController dialogueController;
    [SerializeField] Key key;
    public bool dialogueMode;

    private void Awake()
    {
        PreInitialize();
        key.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }


    protected override void PreInitialize()
    {
        base.PreInitialize();
        animator.SetBool("dialogueMode", dialogueMode);
    }

    public void SetDialogueMode(bool status)
    {
        dialogueMode = status;
        animator.SetBool("dialogueMode", status);
    }

    public void StartPostBattleDialogue()
    {
        dialogueController.StartDialogue();
    }

    public void RevealKey()
    {
        key.gameObject.SetActive(true);
    }
}
