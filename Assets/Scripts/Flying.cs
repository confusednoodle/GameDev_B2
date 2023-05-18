using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //fuel bar
    float fuelDecrease = 0.015f;
    public float fuelCurrent = 100f;
    [SerializeField] AudioSource fuelEmpty;

    public void Start()
    {
        StartCoroutine(WaitForMusic());
    }

    public void Update()
    {
        Vector2 pos = playerRigidbody.velocity;
        if (Input.GetKey(KeyCode.Space))
        {
            fuelCurrent -= fuelDecrease;
            if (fuelCurrent <= 0)
            {
                fuelEmpty.Play();
                currentRotation += rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, 0f, maxRotationAngle);
                transform.rotation = Quaternion.Euler(0f, 0f, -currentRotation);
            }
            else
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
            if (fuelCurrent > 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            Debug.Log("Player collided with obstacle!");

        }
    }

}
