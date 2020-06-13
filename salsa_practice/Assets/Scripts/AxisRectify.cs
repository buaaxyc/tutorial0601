using CrazyMinnow.SALSA;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRectify : MonoBehaviour
{
    //public Transform lookAtTarget;
    public Eyes eyes;

    void Start()
    {
        //transform.TransformPoint(Vector3.zero);
        //transform.LookAt(lookAtTarget, Vector3.down);
        //transform.Rotate(new Vector3(90, 0, 0));
        //eyes.EnableHead(false);
        //eyes.FixAllTransformAxes(ref eyes.heads, true);
        eyes.FixAllTransformAxes(ref eyes.eyes, true);
        Debug.Log("Fix Axis");
    }
}
