using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] DialogueController dialogueController;
    [SerializeField] List<string> lines;
    [SerializeField] int lettersPerSecond = 10;
    //[SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] GameObject arrow;

    TextMeshProUGUI dialogueText;
    int currentLine = 0;

    void Start()
    {
        dialogueText = GetComponent<TextMeshProUGUI>();
        
    }

    public void TypeNextLine()
    {
        ShowArrow(false);

        if (currentLine >= lines.Count)
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
        foreach (var letter in lines[currentLine].ToCharArray())
        {
            dialogueText.text += letter;
            //Debug.Log("made it here");

            yield return new WaitForSeconds(1f / lettersPerSecond);
        }

        currentLine++;
        ShowArrow(true);
    }

    private void ShowArrow(bool isOn)
    {
        arrow.SetActive(isOn);
    }

    private void ConcludeDialogue(bool loadNextScene=false)
    {
        dialogueController.ConcludeDialogue();
        //loadingText.enabled = true;
        //dialogueBackground.SetActive(false);
        //FindObjectOfType<LevelLoader>().LoadNextLevel();
    }
}
