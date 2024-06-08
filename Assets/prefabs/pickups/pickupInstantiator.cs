using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupInstantiator : MonoBehaviour
{
    [SerializeField] GameObject[] pickups;
    [SerializeField] float delayMin = 3f;
    [SerializeField] float delayMax = 6f;

    private bool allowInvoke;

    private void Start()
    {
        allowInvoke = true;
    }

    private void Update()
    {
        if (PickupThere()) return;

        if (allowInvoke)
        {
            Invoke(nameof(InstantiateRandomPickup), GenDelay());
            allowInvoke = false;
        }
    }

    private void InstantiateRandomPickup()
    {
        int pickupIndex = Random.Range(0, pickups.Length);

        GameObject instantiatedPickup = Instantiate(pickups[pickupIndex], transform.position, transform.rotation);
        instantiatedPickup.transform.parent = gameObject.transform;

        allowInvoke = true;

    }

    private float GenDelay()
    {
        return Random.Range(delayMin, delayMax);
    }

    private bool PickupThere()
    {
        return transform.childCount > 0;
    }
}

