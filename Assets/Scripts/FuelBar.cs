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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
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
