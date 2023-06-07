using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OneLiner : MonoBehaviour
{
    [SerializeField] string line;
    [SerializeField] int lettersPerSecond = 10;

    TextMeshProUGUI lineText;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        lineText = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Debug.Log("entered coroutine");

        lineText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            lineText.text += letter;
            //Debug.Log("made it here");

            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
