using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] int numberOfAnmations;
    [SerializeField] float idleTimeMin, idleTimeMax;
    [SerializeField] float moveTimeMin, moveTimeMax;
    [SerializeField] float moveSpeed;

    Animator animator;
    Talker talker;
    bool isTalker;
    Rigidbody2D rb;
    OrientationTracker orientationTracker;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        orientationTracker = GetComponent<OrientationTracker>();
        talker = GetComponent<Talker>();
        isTalker = (talker != null);
    }

    public void TalkerUpdate()
    {
        if (isTalker)
        {
            talker.TalkerUpdate();
        }
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction*moveSpeed, rb.velocity.y);
    }
    public void TurnAround()
    {
        transform.localScale = new Vector2(-1.0f * transform.localScale.x, 1f);
    }

    private void HaltAnimation()
    {
        animator.SetTrigger("halt");
    }

    public void HaltPhysical()
    {
        rb.velocity = new Vector2(0f, 0f);
    }


    public void ExitIdleState()
    {
        float waitTime = Random.Range(idleTimeMin, idleTimeMax);

        Invoke(nameof(GenerateRandomAnimation), waitTime);
    }

    public void ExitMoveState()
    {
        float waitTime = Random.Range(moveTimeMin, moveTimeMax);

        Invoke(nameof(HaltAnimation), waitTime);
    }

    private void GenerateRandomAnimation()
    {
        int animationNumber = Random.Range(0, numberOfAnmations);

        string animationTrigger = "anim" + animationNumber;
        
        animator.SetTrigger(animationTrigger);
    }

    
}
