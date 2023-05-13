using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyMushroom : MonoBehaviour
{
    [SerializeField] AudioSource bounceSound;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceSound.Play();
    }
}
