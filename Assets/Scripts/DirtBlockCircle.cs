using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlockCircle : MonoBehaviour
{
    public float angle;
    public Transform pos;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    void FixedUpdate () {
        transform.RotateAround(pos.position, zAxis, angle); 
    }
}
