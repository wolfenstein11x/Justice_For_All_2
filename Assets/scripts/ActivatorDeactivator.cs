using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorDeactivator : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    [SerializeField] bool activator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            foreach(GameObject item in items)
            {
                item.SetActive(activator);
            }
        }
    }
}
