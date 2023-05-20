using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Flying : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [SerializeField] float upperLimit;
    public float maxRotationAngle = 45f;
    private float currentRotation = 0f;

    [SerializeField] AudioSource bgMusic;
    [SerializeField] AudioSource boostSound;
    private bool isPlaying = false;

    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] Rigidbody2D playerRigidbody;

    [SerializeField] AudioSource crashSound;
    [SerializeField] AudioClip crashSoundClip;
    public bool crashed = false;

    //fuel bar
    float fuelDecrease = 0.015f;
    [SerializeField] FuelBar fuel;
    [SerializeField] AudioSource fuelEmpty;


    //camera
    [SerializeField] Camera mainCamera;
    public void Start()
    {
        StartCoroutine(WaitForMusic());
    }

    //UI text
    [SerializeField] GameObject crashText;

    public void Update()
    {

        if (crashed == true && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
        Vector2 pos = playerRigidbody.velocity;
        if (Input.GetKey(KeyCode.Space))
        {
            if (crashed)
            {
                currentRotation += rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle);
                transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
            }

            if (fuel.fuelCurrent <= 0)
            {
                fuelEmpty.Play();
                currentRotation += rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle);
                transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
            }
            else if (fuel.fuelCurrent > 0 && crashed == false)
            {
                pos.y += speed * Time.deltaTime;
                if (pos.y > upperLimit)
                {
                    pos.y = upperLimit;
                }
                currentRotation -= rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, -maxRotationAngle, 0f);
                transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
                playerRigidbody.velocity = pos;
            }
        }
        else
        {
            currentRotation += rotationSpeed * Time.deltaTime;
            currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle);
            transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fuel.fuelCurrent > 0 && crashed == false)
            {
                boostSound.loop = true;
                boostSound.Play();
                isPlaying = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            boostSound.loop = false;
            isPlaying = false;
        }


    }

    private IEnumerator WaitForMusic()
    {
        yield return new WaitForSeconds(0.8f);
        bgMusic.Play();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && crashed == false)
        {
            crashSound.PlayOneShot(crashSoundClip, 5f);
            this.GetComponent<Animator>().enabled = false;
            this.GetComponent<Rigidbody2D>().drag -= 5;
            mainCamera.GetComponent<CameraMovement>().enabled = false;
            crashText.SetActive(true);
            crashed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (crashed == true)
            {
                crashSound.PlayOneShot(crashSoundClip, 5f);
            }
            else
            {
                crashText.SetActive(true);
                crashSound.PlayOneShot(crashSoundClip, 5f);
                this.GetComponent<Animator>().enabled = false;
                this.GetComponent<Rigidbody2D>().drag -= 5;
                mainCamera.GetComponent<CameraMovement>().enabled = false;
                crashed = true;
            }        
        }
    }
}
