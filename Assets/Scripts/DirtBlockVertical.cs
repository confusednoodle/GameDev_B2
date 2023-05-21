using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlockVertical : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public float distance = 5f; // Distance to move
    public float speed = 2f; // Movement speed

    private Vector3 initialPosition; // Initial position of the sprite
    private float targetPositionY; // Target position to move towards
    private bool isMovingUp = true; // Flag indicating the current movement direction


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        targetPositionY = initialPosition.y + distance;
    }

    private void Update()
    {
        // Calculate the next position based on the movement direction
        float nextPositionY = transform.position.y + (isMovingUp ? speed : -speed) * Time.deltaTime;

        // Move the sprite towards the next position
        transform.position = new Vector3(transform.position.x, nextPositionY, transform.position.z);

        // Check if the sprite has reached the target position
        if ((isMovingUp && nextPositionY >= targetPositionY) || (!isMovingUp && nextPositionY <= initialPosition.y))
        {
            // Reverse the movement direction
            isMovingUp = !isMovingUp;

            // Update the target position
            targetPositionY = isMovingUp ? initialPosition.y + distance : initialPosition.y;
        }
    }
}
