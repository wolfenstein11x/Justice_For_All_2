using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsTilemap : MonoBehaviour
{
    [SerializeField] float damage;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

        if (pc != null)
        {
            pc.ReactToHazard(damage);
        }
    }
}
