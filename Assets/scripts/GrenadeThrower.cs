using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] Grenade grenade;
    [SerializeField] Transform grenadeThrowPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowGrenade()
    {
        Grenade liveGrenade = Instantiate(grenade, grenadeThrowPoint.position, grenade.transform.rotation);
        liveGrenade.transform.parent = gameObject.transform;
    }
}
