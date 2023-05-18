using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFuel : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Image fuelSprite;
    public TextMeshProUGUI fuelText;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(this.gameObject);
        Debug.Log("Hallo");
    }
}
