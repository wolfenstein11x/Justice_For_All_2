using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoTracker : MonoBehaviour
{
    [SerializeField] int startingAmmo;

    int currentAmmo;
    TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();

        currentAmmo = startingAmmo;
        SetAmmoDisplay(currentAmmo);
    }

    private void SetAmmoDisplay(int amount)
    {
        ammoText.text = amount.ToString();
    }

    public void DecrementAmmo()
    {
        if (currentAmmo <= 0) return;

        currentAmmo--;
        SetAmmoDisplay(currentAmmo);
    }

    public void CollectAmmo(int amount)
    {
        currentAmmo += amount;
        SetAmmoDisplay(currentAmmo);
    }

    public int GetAmmoCount()
    {
        return currentAmmo;
    }
}
