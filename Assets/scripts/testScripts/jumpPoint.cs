using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPoint : MonoBehaviour
{
    [SerializeField] MotionTest patroller;
    [SerializeField] float proximityThreshold = 0.1f;

    float proximityToPatroller;
    bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jumping) return;

        if (proximityToPatroller <= proximityThreshold)
        {
            jumping = true;
            
        }
    }

    private void MeasureProximity()
    {
        proximityToPatroller = Vector2.Distance(transform.position, patroller.transform.position);
        //Debug.Log(gameObject.name + ": " + proximityToPatroller);
    }
}
