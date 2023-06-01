using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : ObjectHealth
{
    [SerializeField] MovingDoor movingDoor;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    protected override void Die()
    {
        if (animator.GetBool("switchedOn")) return;

        //breakSound.Play();
        animator.SetBool("switchedOn", true);
        movingDoor.Open();
    }
}
