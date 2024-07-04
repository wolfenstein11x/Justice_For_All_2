using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogueController : MonoBehaviour
{
    [SerializeField] GameObject dialogueButtonBackground;
    [SerializeField] DialogueBackground dialogueBackground;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] int lettersPerSecond = 10;
    [SerializeField] float startDialogueDelay = 0.25f;


    List<string> currentTalkerLines;
    PlayerController pc;
    Talker currentTalker;
    MenuController menuController;
    MusicController musicController;
    SceneLoader sceneLoader;
    int currentLine = 0;

    private void Awake()
    {
        ShowDialogueButton(false);
        ShowDialogueBackground(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        menuController = FindObjectOfType<MenuController>();
        musicController = FindObjectOfType<MusicController>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (pc.InDialogueMode()) return;

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
            currentTalker.SetTalkMode(true);
            SetCurrentTalkerUI();
            menuController.ShowControlsPanels(false);
            ShowDialogueBackground(true);
            ProcessTalkerTagStartOfDialogue(currentTalker);

            // give short delay before typing line to give Dialogue game object enough time to initialize, preventing null reference error
            Invoke(nameof(TypeNextLine), startDialogueDelay);
        }
    }

    private void SetCurrentTalkerUI()
    {
        dialogueBackground.SetNameText(currentTalker.name);
        dialogueBackground.SetHeadShot(currentTalker.headShot);
        currentTalkerLines = currentTalker.lines;
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

    public void TypeNextLine()
    {
        dialogueBackground.ShowDialogueArrow(false);
        //Debug.Log(currentTalkerLines[0]);
        if (currentLine >= currentTalkerLines.Count)
        {
            ConcludeDialogue();
            return;
        }

        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        //Debug.Log("entered coroutine");

        dialogueText.text = "";
        foreach (var letter in currentTalkerLines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            //Debug.Log("made it here");

            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        currentLine++;
        dialogueBackground.ShowDialogueArrow(true);
    }

    public void ConcludeDialogue()
    {
        dialogueText.text = "";
        currentLine = 0;
        dialogueBackground.ClearHeadShot();
        ShowDialogueBackground(false);
        menuController.ShowControlsPanels(true);
        currentTalker.SetTalkMode(false);

        ProcessTalkerTagPostDialogue(currentTalker);
    }

    private void ProcessTalkerTagPostDialogue(Talker talker)
    {
        if (talker.tag == "boss")
        {
            talker.SetDoneTalking(true);
            talker.SetNPCmode(false);
            talker.ActivatePostDialogueItem();
        }

        else if (talker.tag == "elite")
        {
            talker.SetDoneTalking(true);
            sceneLoader.LoadNextLevel();
        }
    }

    private void ProcessTalkerTagStartOfDialogue(Talker talker)
    {
        if (talker.tag == "boss")
        {
            musicController.PlaySong(1);
        }

        else if (talker.tag == "elite")
        {
            musicController.PlaySong(2);
        }
    }
}
