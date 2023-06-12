using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneDoor : MonoBehaviour
{
    [SerializeField] Health[] enemies;

    MovingDoor movingDoor;

    // Start is called before the first frame update
    void Start()
    {
        movingDoor = GetComponent<MovingDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesDead())
        {
            movingDoor.Open();
        }
    }

    private bool EnemiesDead()
    {
        foreach(Health enemy in enemies)
        {
            if (enemy != null)
            {
                return false;
            }
        }

        return true;
    }
}
