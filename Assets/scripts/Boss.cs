using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    //[SerializeField] bool faceLeft;

    public bool dialogueMode;

    private void Awake()
    {
        PreInitialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PreInitialize()
    {
        base.PreInitialize();
        animator.SetBool("dialogueMode", dialogueMode);
    }

    private void FaceLeft()
    {

    }
}
