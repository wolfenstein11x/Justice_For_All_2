using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    [SerializeField] bool startOpen;
    [SerializeField] AudioSource openSound;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("open", startOpen);
    }

    public void Open()
    {
        if (animator.GetBool("open") == true) return;

        animator.SetBool("open", true);
        openSound.Play();
    }

    public void Close()
    {
        animator.SetBool("open", false);
    }

    

   
}
