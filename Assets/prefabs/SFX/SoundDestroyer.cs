using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    // this is a temporary fix for a bug that is causing sound instances to remain in the heirarchy forever

    void Start()
    {
        Destroy(gameObject, 1.395f);
    }

    
}
