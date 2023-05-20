using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBirbMovement : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;
    public float distance = 5f; // Distance to move
    public float speed = 2f; // Movement speed

    private Vector3 initialPosition; // Initial position of the sprite
    private float targetPositionX; // Target position to move towards
    private bool isMovingRight = true; // Flag indicating the current movement direction
    private int dashCount = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        targetPositionX = initialPosition.x + distance;
    }

    private void Update()
    {
        if (dashCount % 3 == 0 && dashCount > 0)
        {
            speed = 4f;
        }

        else
        {
            speed = 2f;
        }
        // Calculate the next position based on the movement direction
        float nextPositionX = transform.position.x + (isMovingRight ? speed : -speed) * Time.deltaTime;

        // Move the sprite towards the next position
        transform.position = new Vector3(nextPositionX, transform.position.y, transform.position.z);

        // Check if the sprite has reached the target position
        if ((isMovingRight && nextPositionX >= targetPositionX) || (!isMovingRight && nextPositionX <= initialPosition.x))
        {
            // Flip the sprite horizontally
            spriteRenderer.flipX = !spriteRenderer.flipX;

            // Reverse the movement direction
            isMovingRight = !isMovingRight;
            dashCount += 1;

            // Update the target position
            targetPositionX = isMovingRight ? initialPosition.x + distance : initialPosition.x;
        }
    }
}
