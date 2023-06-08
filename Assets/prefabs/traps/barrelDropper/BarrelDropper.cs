using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDropper : MonoBehaviour
{
    [SerializeField] ExplodingBarrel explodingBarrel;
    [SerializeField] float delayMin = 3f;
    [SerializeField] float delayMax = 6f;

    private bool allowInvoke;
    private BossHealth bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        allowInvoke = true;
        bossHealth = FindObjectOfType<BossHealth>();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DropBarrel));
        //Debug.Log("cancelled invoke");
    }

    // Update is called once per frame
    void Update()
    {
        if (allowInvoke)
        {
            Invoke(nameof(DropBarrel), GenDelay());
            allowInvoke = false;
        }
    }

    private void DropBarrel()
    {
        ExplodingBarrel explodingBarrelInstance = Instantiate(explodingBarrel, transform.position, transform.rotation);
        allowInvoke = true;
    }

    private float GenDelay()
    {
        return Random.Range(delayMin, delayMax);
    }
}
