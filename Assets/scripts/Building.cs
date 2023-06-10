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
    EntryControls entryControls;

    // Start is called before the first frame update
    void Start()
    {
        LockUnlockBuilding(locked);
        entryControls = FindObjectOfType<EntryControls>();
    }

    private bool PlayerOutside()
    {
        return exterior.activeSelf;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pc = collision.gameObject.GetComponent<PlayerController>();
        playerSR = collision.gameObject.GetComponent<SpriteRenderer>();

        if (pc != null)
        {
            entryControls.LinkToBuilding(this);

            if (PlayerOutside() && locked && pc.hasKey)
            {
                entryControls.RevealButton(2);
            }

            else if (PlayerOutside() && !locked)
            {
                entryControls.RevealButton(0);
            }

            else if (!PlayerOutside())
            {
                entryControls.RevealButton(1);
            }

            /*
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
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pc = collision.gameObject.GetComponent<PlayerController>();

        if (pc != null)
        {
            entryControls.HideAllButtons();
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

   
    public void EnterBuilding()
    {
        // change player sorting layer so that we can see him indoors
        playerSR.sortingLayerName = "indoorPlayer";

        interior.SetActive(true);
        exterior.SetActive(false);
        SetTilemaps(true);

        // prevent any enemies outside the house from attacking player through the walls
        SetOutsideEnemies(false);
    }

    public void ExitBuilding()
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
