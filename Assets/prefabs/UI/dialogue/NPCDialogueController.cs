using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueButtonBackground;


    PlayerController pc;
    Talker currentTalker;

    private void Awake()
    {
        dialogueButtonBackground.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttemptInitiateDialogue()
    {
        if (pc.TalkerInSight() && currentTalker.PlayerInSight())
        {
            Debug.Log(currentTalker.name);
        }
    }

    public void SetCurrentTalker(Talker talker)
    {
        currentTalker = talker;
        Debug.Log(currentTalker.name);
    }

    public bool IsCurrentTalker(Talker talker)
    {
        return currentTalker == talker;
    }
}
