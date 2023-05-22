using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDebugging : MonoBehaviour
{
    [SerializeField] GameObject thing;

    private void Awake()
    {
        thing.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            thing.SetActive(true);
        }
    }
}
