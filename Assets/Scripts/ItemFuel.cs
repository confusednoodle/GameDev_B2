using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemFuel : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Image fuelSprite;
    [SerializeField] FuelBar fuel;
    [SerializeField] Flying plane;
    //public AudioSource itemCollected;
    //public AudioClip itemCollectedClip;
    public float fuelIncreased;
    public TextMeshProUGUI fuelText;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (plane.crashed == false)
        {
            //itemCollected.PlayOneShot(itemCollectedClip, 0.5f);
            fuelSprite.fillAmount += 0.3f;
            fuelIncreased = fuel.fuelCurrent + 30f;
            if (fuelIncreased >= 100f)
            {
                fuelIncreased = 100f;
            }
            fuelText.text = fuelIncreased.ToString("F0");
            fuel.fuelCurrent = fuelIncreased;
            Destroy(this.gameObject);
            //StartCoroutine(WaitForDestruction());
        }
    }

    /*private IEnumerator WaitForDestruction()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }*/
}
