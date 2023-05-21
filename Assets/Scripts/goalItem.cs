using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalItem : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Image goalSprite;


    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
    }
}