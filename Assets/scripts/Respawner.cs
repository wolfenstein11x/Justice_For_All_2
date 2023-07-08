using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] float respawnTimeMin, respawnTimeMax;

    private bool dormant = true;

    Animator animator;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsDormant()
    {
        return dormant;
    }

    public void SetDormant(bool status)
    {
        dormant = status;
    }

    public void InitiateRespawn()
    {
        if (IsDormant()) return;

        float waitTime = Random.Range(respawnTimeMin, respawnTimeMax);
        Invoke(nameof(Respawn), waitTime);
    }

    private void Respawn()
    {
        if (IsDormant()) return;

        health.Revive();
        animator.SetTrigger("respawn");
    }

    public void Spawn()
    {
        SetDormant(false);
        animator.SetTrigger("wakeUp");
    }

    public void Deactivate()
    {
        SetDormant(true);
        health.ForceDie();
    }
}
