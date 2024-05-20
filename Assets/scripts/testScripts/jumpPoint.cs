using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    [SerializeField] Jumper jumper;
    [SerializeField] float proximityThreshold = 0.1f;
    [SerializeField] float resetTime = 1f;
    [SerializeField] bool jumpUpPoint = true;


    float proximityToJumper;
    bool recentInteraction;

    private void OnDrawGizmos()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(pos, 0.25f);
    }

    // Start is called before the first frame update
    void Start()
    {
        recentInteraction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (recentInteraction) return;

        MeasureProximity();

        if (proximityToJumper <= proximityThreshold)
        {
            recentInteraction = true;

            if (jumpUpPoint) jumper.JumpDiagonalUp();
            else jumper.JumpDiagonalDown();

            Invoke(nameof(ClearRecentInteraction), resetTime);

        }
    }

    private void MeasureProximity()
    {
        proximityToJumper = Vector2.Distance(transform.position, jumper.transform.position);
        //Debug.Log(gameObject.name + ": " + proximityToJumper);
    }

    private void ClearRecentInteraction()
    {
        recentInteraction = false;
    }
}

