using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // red icon means turn around point, blue icon means jump point

    [SerializeField] Enemy patroller;
    [SerializeField] [Range(0f, 1f)] float jumpProbability, turnProbability;
    [SerializeField] bool optional;
    [SerializeField] float proximityThreshold = 0.1f;
    [SerializeField] float resetTime = 1f;

    float[] probabilities;
    float proximityToPatroller;
    bool recentInteraction;

    private void OnDrawGizmos()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        Gizmos.color = new Color(turnProbability, 0, jumpProbability, 1f);
        Gizmos.DrawSphere(pos, 0.25f);
    }

    // Start is called before the first frame update
    void Start()
    {
        recentInteraction = false;
        probabilities = new float[] { turnProbability, jumpProbability };
    }

    // Update is called once per frame
    void Update()
    {
        if (recentInteraction) return;

        MeasureProximity();

        if (proximityToPatroller <= proximityThreshold)
        {
            // prevent enemy from jumping/turning away from a fight for seemingly no reason
            if (optional && patroller.InAttackMode()) return;

            recentInteraction = true;
            //Debug.Log(proximityToPatroller);
            MakeDecision();
            Invoke(nameof(ClearRecentInteraction), resetTime);
        }

    }

    private void MeasureProximity()
    {
        proximityToPatroller = Vector2.Distance(transform.position, patroller.transform.position);
        //Debug.Log(gameObject.name + ": " + proximityToPatroller);
    }

    private void MakeDecision()
    {
        // generate random number between 0 and 1
        float decision = Random.Range(0f, 1f);

        // ex: if waypoint has 90 percent jump probability, then jumpProbability = 0.9 and turnProbability = 0.1
        // 90 percent chance random number is <= 0.9
        // 10 percent change random number is <= 0.1
        // make decision based on smaller probability, because if for example decision = 0.05 and first compares with jump probability, it will jump even though it should turn around

        // make decision given that turnProbability is the smaller probability
        if (turnProbability <= jumpProbability)
        {
            if (decision <= turnProbability)
            {
                patroller.TurnAround();
            }

            else if (decision <= jumpProbability)
            {
                patroller.Jump();
            }
        }

        // make decision given that jumpProbability is the smaller probability
        else if (jumpProbability <= turnProbability)
        {
            if (decision <= jumpProbability)
            {
                patroller.Jump();
            }

            else if (decision <= turnProbability)
            {
                patroller.TurnAround();
            }
        }
    }

    private void ClearRecentInteraction()
    {
        recentInteraction = false;
    }
}
