using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField] float FallSpeed;

    bool falling = false;

    void FixedUpdate()
    {
        if (falling) {
            transform.position -= new Vector3(0, FallSpeed, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        falling = true;
    }
}
