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
    [SerializeField] Enemy[] outsideEnemies;

    PlayerController pc;
    SpriteRenderer playerSR;

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
        playerSR = collision.gameObject.GetComponent<SpriteRenderer>();

        if (pc != null)
        {
            if (pc.AttemptingToEnter() && locked && pc.hasKey)
            {
                LockUnlockBuilding(false);
                return;
            }

            else if (pc.AttemptingToEnter() && !locked)
            {
                EnterBuilding(playerSR);
            }

            else if (pc.AttemptingToExit())
            {
                ExitBuilding(playerSR);
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

   
    private void EnterBuilding(SpriteRenderer sr)
    {
        // change player sorting layer so that we can see him indoors
        sr.sortingLayerName = "indoorPlayer";

        interior.SetActive(true);
        exterior.SetActive(false);
        SetTilemaps(true);

        // prevent any enemies outside the house from attacking player through the walls
        SetOutsideEnemies(false);
    }

    private void ExitBuilding(SpriteRenderer sr)
    {
        // set player sorting layer back to normal
        playerSR.sortingLayerName = "player";

        interior.SetActive(false);
        exterior.SetActive(true);
        SetTilemaps(false);

        SetOutsideEnemies(true);
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

    private void SetOutsideEnemies(bool status)
    {
        foreach(Enemy enemy in outsideEnemies)
        {
            if (enemy.gameObject != null)
            {
                enemy.gameObject.SetActive(status);
            }
        }
    }
}
