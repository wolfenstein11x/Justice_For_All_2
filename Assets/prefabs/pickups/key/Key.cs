using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] AudioSource pickupSound;

    Animator animator;

    bool obtained;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        obtained = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obtained) return;

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            animator.SetTrigger("pickup");

            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.PickupKey();
            pickupSound.Play();

            Destroy(gameObject, 3f);

        }
    }
}
