using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] int numberOfAnmations;
    [SerializeField] float idleTimeMin, idleTimeMax;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void ExitIdleState()
    {
        float waitTime = Random.Range(idleTimeMin, idleTimeMax);

        Invoke(nameof(GenerateRandomAnimation), waitTime);
    }

    private void GenerateRandomAnimation()
    {
        int animationNumber = Random.Range(0, numberOfAnmations);

        string animationTrigger = "anim" + animationNumber;
        
        animator.SetTrigger(animationTrigger);
    }
}
