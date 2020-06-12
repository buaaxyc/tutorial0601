using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position_transport : MonoBehaviour
{
    public GameObject obj;

    public void PositionTransport()
    {
        obj.transform.TransformPoint(Vector3.zero);
        Debug.Log("yyy");
    }
}
