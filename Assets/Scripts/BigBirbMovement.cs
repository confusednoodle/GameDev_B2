using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBirbMovement : MonoBehaviour
{
    public Transform spriteTransform;
    public float targetScale = 2f;
    public float duration = 3f;
    [SerializeField] SpriteRenderer birbSprite;

    private Vector3 initialScale;
    private float currentTime = 0f;
    //public bool facingRight = true;

    private void Start()
    {
        initialScale = spriteTransform.localScale;
    }

    private void Update()
    {
        if (birbSprite.flipX == false)
        {
            if (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float t = currentTime / duration;
                spriteTransform.localScale = Vector3.Lerp(initialScale, initialScale * targetScale, t);
            }

            else if (currentTime < 2 * duration)
            {
                currentTime += Time.deltaTime;
                float t = (currentTime - duration) / duration;
                spriteTransform.localScale = Vector3.Lerp(initialScale * targetScale, initialScale, t);
            }

            else
            {
                currentTime = 0f;
                spriteTransform.localScale = initialScale;
                birbSprite.flipX = true;
            }

        }

        if (birbSprite.flipX == true)
        {
            if (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float t = currentTime / duration;
                spriteTransform.localScale = Vector3.Lerp(initialScale, initialScale * targetScale, t);
            }

            else if (currentTime < 2 * duration)
            {
                currentTime += Time.deltaTime;
                float t = (currentTime - duration) / duration;
                spriteTransform.localScale = Vector3.Lerp(initialScale * targetScale, initialScale, t);
            }

            else
            {
                currentTime = 0f;
                spriteTransform.localScale = initialScale;
                birbSprite.flipX = false;
            }

        }
    }

}
