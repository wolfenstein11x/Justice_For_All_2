using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationTracker : MonoBehaviour
{
    [SerializeField] bool leftFacingSprite = false;

    public float GetOrientation()
    {
        if (leftFacingSprite) return Mathf.Sign(-1f*transform.localScale.x) * 1.0f;
        else return Mathf.Sign(transform.localScale.x) * 1.0f;
    }
}
