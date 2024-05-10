using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBackground : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] Transform headShotPosition;
    [SerializeField] GameObject dialogueArrow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetNameText(string name)
    {
        nameText.text = name;
    }

    public void SetHeadShot(GameObject currentTalkerHeadShot)
    {
        //headShot = currentTalkerHeadShot;
        Instantiate(currentTalkerHeadShot, headShotPosition);
    }

    public void ShowDialogueArrow(bool status)
    {
        dialogueArrow.SetActive(status);
    }
}
