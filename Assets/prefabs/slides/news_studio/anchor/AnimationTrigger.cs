using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string onEnableTrigger;
    [SerializeField] string onDisableTrigger;

    private void OnEnable()
    {
        animator.SetTrigger(onEnableTrigger);
    }

    private void OnDisable()
    {
        animator.SetTrigger(onDisableTrigger);
    }
}
