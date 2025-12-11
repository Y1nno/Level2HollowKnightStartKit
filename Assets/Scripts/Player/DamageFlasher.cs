using System.Collections;
using UnityEngine;

public class DamageFlasher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color flashColor = Color.red;
    public float flashCycleLength = 0.01f; // Duration of one flash cycle
    public float flashingDuration = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        //spriteRenderer.color = flashColor;
    }

    public void TriggerDamageFlash()
    {
        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRoutine());
        }
    }

    IEnumerator FlashRoutine()
    {
        // Change to flash color
        for (float x = 1f; x < flashingDuration / flashCycleLength; x++)
        {
            spriteRenderer.color = flashColor;

            yield return new WaitForSeconds(flashCycleLength);

            spriteRenderer.color = originalColor;
        }
        
    }
}
