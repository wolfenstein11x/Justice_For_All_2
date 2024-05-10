using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueButtonBackground;
    [SerializeField] DialogueBackground dialogueBackground;


    PlayerController pc;
    Talker currentTalker;

    private void Awake()
    {
        ShowDialogueButton(false);
        ShowDialogueBackground(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.InDialogueMode()) return;

        ShowDialogueButton(TalkersInPosition());
    }

    private bool TalkersInPosition()
    {
        if (currentTalker == null) return false;

        else return (pc.TalkerInSight() && currentTalker.PlayerInSight());
    }

    public void AttemptInitiateDialogue()
    {
        if (TalkersInPosition())
        {
            dialogueBackground.SetNameText(currentTalker.name);
            dialogueBackground.SetHeadShot(currentTalker.headShot);
            ShowDialogueBackground(true);
        }
    }

    public void ShowDialogueButton(bool status)
    {
        dialogueButtonBackground.SetActive(status);
    }

    private void ShowDialogueBackground(bool status)
    {
        dialogueBackground.gameObject.SetActive(status);
    }

    public void SetCurrentTalker(Talker talker)
    {
        currentTalker = talker;
        //Debug.Log(currentTalker.name);
    }

    public bool IsCurrentTalker(Talker talker)
    {
        return currentTalker == talker;
    }
}
