using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    [SerializeField] float sightRange = 2f;
    [SerializeField] LayerMask sightRaycastLayers;
    [SerializeField] float talkBuffer = 2f;
    public GameObject headShot;
    public List<string> lines;

    NPCDialogueController npcDialogueController;
    OrientationTracker orientationTracker;
    Animator animator;
    PlayerController pc;
    bool doneTalking;

    // Start is called before the first frame update
    void Start()
    {
        npcDialogueController = FindObjectOfType<NPCDialogueController>();
        orientationTracker = GetComponent<OrientationTracker>();
        animator = GetComponent<Animator>();
        pc = FindObjectOfType<PlayerController>();
        SetNPCmode(true);
        doneTalking = false;
    }

    private void Update()
    {
        if (doneTalking) return;

        if (npcDialogueController.IsCurrentTalker(this)) return;

        if (PlayerInSight() && pc.TalkerInSight())
            {
                npcDialogueController.SetCurrentTalker(this);
            }

        

    }


    public bool PlayerInSight()
    {
        if (doneTalking) return false;

        float orientation = orientationTracker.GetOrientation();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * new Vector2(orientation, 0f), sightRange, sightRaycastLayers);

        // ray hit something, could be a wall or a target
        if (hit.collider != null)
        {
            // ray hit Player, because only a Player would have PlayerController
            if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
            {
                //Debug.DrawRay(transform.position, Vector2.right * hit.distance * new Vector2(orientation, 0f), Color.red);
                if (PlayerTooClose()) return false;
                else return true;
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


    private bool PlayerTooClose()
    {
        Vector3 playerPos = pc.transform.position;
        float distance = Vector3.Distance(transform.position, playerPos);
        return distance <= talkBuffer;
    }

    public void SetTalkMode(bool status)
    {
        animator.SetBool("talkMode", status);
    }

    public void SetDoneTalking(bool status)
    {
        doneTalking = status;
    }

    public void SetNPCmode(bool status)
    {
        //Debug.Log(animator.GetBool("npcMode"));
        animator.SetBool("npcMode", status);
    }
}
