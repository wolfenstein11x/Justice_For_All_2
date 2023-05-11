using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hitPoints = 20f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (hitPoints <= 0) return;

        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
    }
}
