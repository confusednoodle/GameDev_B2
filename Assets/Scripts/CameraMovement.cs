using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1.0f; // Adjust the speed of camera movement here

    void Update()
    {
        if(this.transform.position.x <= 69)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
    
}
