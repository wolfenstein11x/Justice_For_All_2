using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupButton : MonoBehaviour
{
    [SerializeField] float powerupDuration = 10f;
    [SerializeField] int powerupIndex = 1;
    [SerializeField] AudioSource powerupSound;
    [SerializeField] float soundDuration;

    Image buttonImage;
    Button button;
    bool powerupActive = false;
    AttackButtons attackButtons;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        SetButtonActive(false);
        attackButtons = FindObjectOfType<AttackButtons>();
    }

    public void SetButtonActive(bool status)
    {
        buttonImage.enabled = status;
        button.enabled = status;
    }

    public void PushPowerupButton()
    {
        if (powerupActive) return;

        powerupActive = true;
        StartCoroutine(PowerupButtonCoroutine());
    }

    IEnumerator PowerupButtonCoroutine()
    {
        attackButtons.ActivateShootButton(powerupIndex);
        AudioSource powerupSoundInstance = Instantiate(powerupSound, transform.position, transform.rotation);
        Destroy(powerupSoundInstance, soundDuration);

        Color c = buttonImage.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            buttonImage.color = c;
            yield return new WaitForSeconds(1.0f / powerupDuration);
        }

        attackButtons.ActivateShootButton(0);
        SetButtonActive(false);
        powerupActive = false;
    }
}
