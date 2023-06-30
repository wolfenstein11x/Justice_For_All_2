using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    [SerializeField] bool startOn = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (startOn)
        {
            animator.SetBool("fireStarted", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            animator.SetBool("fireStarted", true);
        }
    }
}
