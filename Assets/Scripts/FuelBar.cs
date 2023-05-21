using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FuelBar : MonoBehaviour
{

    [SerializeField] Image fuelSprite;
    [SerializeField] float fuelDecrease;
    public TextMeshProUGUI fuelText;
    public float fuelCurrent = 100f;
    [SerializeField] Flying plane;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && plane.crashed == false)
        {
            fuelSprite.fillAmount -= fuelDecrease * 1/100;
            fuelCurrent -= fuelDecrease;
            if (fuelCurrent <= 0)
            {
                fuelText.text = "Empty";
            }
            else
            {
                fuelText.text = fuelCurrent.ToString("F0");
            }
        }
    }
}
