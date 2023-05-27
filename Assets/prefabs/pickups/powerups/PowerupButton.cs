using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour
{
    Image buttonImage;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();

        SetButtonActive(false);
    }

    public void SetButtonActive(bool status)
    {
        buttonImage.enabled = status;
        button.enabled = status;
    }
}
