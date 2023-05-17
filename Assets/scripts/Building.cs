using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Building : MonoBehaviour
{
    [SerializeField] bool locked;
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject exterior;
    [SerializeField] GameObject interior;
    [SerializeField] SpriteRenderer[] nearbySprites;
    [SerializeField] GameObject[] nearbySpriteParents;

    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        LockUnlockBuilding(locked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pc = collision.gameObject.GetComponent<PlayerController>();

        if (pc != null)
        {
            if (pc.AttemptingToEnter() && !locked)
            {
                EnterBuilding();
            }

            else if (pc.AttemptingToExit())
            {
                ExitBuilding();
            }
        }
    }

    public void LockUnlockBuilding(bool status)
    {
        locked = status;

        foreach(GameObject door in doors)
        {
            door.SetActive(status);
        }
    }

    private void SetNearbySprites(bool visible)
    {
        foreach (SpriteRenderer sr in nearbySprites)
        {
            sr.enabled = visible;
        }

        foreach (GameObject spriteParent in nearbySpriteParents)
        {
            SpriteRenderer[] spriteChildren = spriteParent.GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer sprite in spriteChildren)
            {
                sprite.enabled = visible;
            }
        }
    }


    private void EnterBuilding()
    {
        SetNearbySprites(false);

        exterior.SetActive(false);
        SetTilemaps(true);
        interior.SetActive(true);
    }

    private void ExitBuilding()
    {
        SetNearbySprites(true);

        interior.SetActive(false);
        exterior.SetActive(true);
        SetTilemaps(false);
    }

    private void SetTilemaps(bool indoors)
    {
        TilemapRenderer[] tilemaps = FindObjectsOfType<TilemapRenderer>();

        foreach (TilemapRenderer tilemap in tilemaps)
        {
            if (tilemap.name == "IndoorBackgroundTilemap")
            {
                tilemap.enabled = indoors;
            }

            else
            {
                tilemap.enabled = !indoors;
            }
        }
    }
}
