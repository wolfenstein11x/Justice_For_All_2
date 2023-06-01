using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    [SerializeField] bool startOpen;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("open", startOpen);
    }

    public void Open()
    {
        animator.SetBool("open", true);
    }

    public void Close()
    {
        animator.SetBool("open", false);
    }

   
}
