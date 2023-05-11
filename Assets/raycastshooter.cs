using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastshooter : MonoBehaviour
{
    [SerializeField] float fireRange = 15f;
    [SerializeField] float meleeRange = 5f;
    [SerializeField] Transform gunPos;
    [SerializeField] Transform meleePos;

    LayerMask fireRaycastLayers;
    LayerMask meleeRaycastLayers;

    // Start is called before the first frame update
    void Start()
    {
        fireRaycastLayers = LayerMask.GetMask("Player") | LayerMask.GetMask("Ground");
        meleeRaycastLayers = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        RaycastHit2D hitGun = Physics2D.Raycast(gunPos.position, Vector2.left, fireRange, fireRaycastLayers);
        RaycastHit2D hitMelee = Physics2D.Raycast(meleePos.position, Vector2.left, meleeRange, meleeRaycastLayers);

        if (hitGun.collider != null)
        {
            Debug.DrawRay(gunPos.position, Vector2.left * hitGun.distance, Color.red);
        }

        else
        {
            Debug.DrawRay(gunPos.position, Vector2.left * fireRange, Color.blue);
        }

        if (hitMelee.collider != null)
        {
            Debug.DrawRay(meleePos.position, Vector2.left * hitMelee.distance, Color.red);
        }

        else
        {
            Debug.DrawRay(meleePos.position, Vector2.left * meleeRange, Color.blue);
        }
    }
}
