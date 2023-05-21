using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public Transform spriteTransform;
    public float targetScale = 1.2f;
    public float duration = 1f;

    private Vector3 initialScale;
    private float currentTime = 0f;

    private void Start()
    {
        initialScale = spriteTransform.localScale;
    }

    private void Update()
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
        }

    }
}