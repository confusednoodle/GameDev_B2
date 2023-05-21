using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoringBirb : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    private int count = 0;

    void Update()
    {
        count += 1;
        if (count % 2000 == 0)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
