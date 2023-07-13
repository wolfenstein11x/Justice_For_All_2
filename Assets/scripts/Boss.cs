using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] DialogueController dialogueController;
    [SerializeField] Key key;
    [SerializeField] BoxCollider2D deadCollider;
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
        deadCollider.enabled = false;
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

    public void AdjustColliders()
    {
        BoxCollider2D regularCollider = GetComponent<BoxCollider2D>();
        deadCollider.enabled = true;
        regularCollider.enabled = false;
    }
}
