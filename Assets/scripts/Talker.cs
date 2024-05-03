using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField] float sightRange = 2f;
    [SerializeField] LayerMask sightRaycastLayers;
    [SerializeField] GameObject dialogueCanvas;
    [SerializeField] GameObject UImain;
    [SerializeField] float talkBuffer = 2f;

    OrientationTracker orientationTracker;
    Animator animator;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue(false);
        orientationTracker = GetComponent<OrientationTracker>();
        animator = GetComponent<Animator>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (PlayerInSight())
        {
            if (pc.TalkerInSight(sightRange) && !PlayerTooClose())
            {
                animator.SetTrigger("talk");
            }
        }
    }


    public bool PlayerInSight()
    {
        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * new Vector2(orientation, 0f), sightRange, sightRaycastLayers);

        // ray hit something, could be a wall or a target
        if (hit.collider != null)
        {
            // ray hit Player, because only a Player would have PlayerController
            if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
            {
                //Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
                return true;
            }

            // ray hit a wall
            else
            {
                //Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.yellow);
                return false;
            }

        }

        // ray hit nothing
        else
        {
            //Debug.DrawRay(transform.position, Vector2.right * sightRange * new Vector2(orientation, 0f), Color.blue);
            return false;
        }
    }

    public void StartDialogue(bool status)
    {
        if (status == true)
        {
            pc.SetDialogueMode(true);
        }

        UImain.SetActive(!status);
        dialogueCanvas.SetActive(status);
    }

    private bool PlayerTooClose()
    {
        Vector3 playerPos = pc.transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);
        return distance <= talkBuffer;
    }
}
