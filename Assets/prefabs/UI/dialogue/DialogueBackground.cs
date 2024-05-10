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

    GameObject headShot;
    
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
        headShot = Instantiate(currentTalkerHeadShot, headShotPosition);
    }

    public void ClearHeadShot()
    {
        Destroy(headShot);
    }
 

    public void ShowDialogueArrow(bool status)
    {
        dialogueArrow.SetActive(status);
    }
}
