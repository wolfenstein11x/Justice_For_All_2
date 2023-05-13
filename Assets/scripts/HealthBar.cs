using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    //Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void ShowHealAnimation()
    {
        //animator.SetTrigger("heal");
    }

    public float GetMaxHealth()
    {
        return slider.maxValue;
    }
}
