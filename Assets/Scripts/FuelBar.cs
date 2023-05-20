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
    //public AudioSource itemCollected;
    //public AudioClip itemCollectedClip;
    [SerializeField] Flying plane;

    void Update()
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
