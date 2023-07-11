using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    [SerializeField] CheckBox[] otherBoxes;
    [SerializeField] GameObject checkMark;

    private bool isChecked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckSelf()
    {
        foreach(CheckBox checkBox in otherBoxes)
        {
            checkBox.UncheckSelf();
        }

        checkMark.SetActive(true);
        isChecked = true;
    }

    public void UncheckSelf()
    {
        checkMark.SetActive(false);
        isChecked = false;
    }

    public bool IsChecked()
    {
        return isChecked;
    }
}
