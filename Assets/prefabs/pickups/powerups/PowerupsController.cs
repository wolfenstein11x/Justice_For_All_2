using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsController : MonoBehaviour
{
    bool powerupActive;

    // Start is called before the first frame update
    void Start()
    {
        powerupActive = false;
    }

    public bool PowerupActive()
    {
        return powerupActive;
    }

    public void SetPowerupActive(bool status)
    {
        powerupActive = status;
    }
}
