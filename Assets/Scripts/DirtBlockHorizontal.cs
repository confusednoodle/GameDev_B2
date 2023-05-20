using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlockHorizontal : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    public float distance = 5f; // Distance to move
    public float speed = 2f; // Movement speed

    private Vector3 initialPosition; // Initial position of the sprite
    private float targetPositionX; // Target position to move towards
    private bool isMovingRight = true; // Flag indicating the current movement direction


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        targetPositionX = initialPosition.x + distance;
    }

    private void Update()
    {
        // Calculate the next position based on the movement direction
        float nextPositionX = transform.position.x + (isMovingRight ? speed : -speed) * Time.deltaTime;

        // Move the sprite towards the next position
        transform.position = new Vector3(nextPositionX, transform.position.y, transform.position.z);

        // Check if the sprite has reached the target position
        if ((isMovingRight && nextPositionX >= targetPositionX) || (!isMovingRight && nextPositionX <= initialPosition.x))
        {
            // Reverse the movement direction
            isMovingRight = !isMovingRight;

            // Update the target position
            targetPositionX = isMovingRight ? initialPosition.x + distance : initialPosition.x;
        }
    }
}
