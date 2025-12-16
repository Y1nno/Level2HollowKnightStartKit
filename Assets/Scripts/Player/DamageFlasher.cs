using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlasher : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    private List<Color> originalColors;
    public Color flashColor = Color.red;
    public float flashCycleLength = 0.01f; // Duration of one flash cycle
    public float flashingDuration = 1f;

    void Start()
    {
        if (spriteRenderers == null)
        {
            spriteRenderers = new List<SpriteRenderer>();
        }

        // If no renderers were assigned in the inspector, add the component on this GameObject
        if (spriteRenderers.Count == 0)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                spriteRenderers.Add(sr);
            }
        }

        // Capture original colors for each renderer
        originalColors = new List<Color>(spriteRenderers.Count);
        foreach (var sr in spriteRenderers)
        {
            originalColors.Add(sr != null ? sr.color : Color.white);
        }
    }

    public void TriggerDamageFlash()
    {
        if (spriteRenderers != null && spriteRenderers.Count > 0)
        {
            Debug.Log("Damage Flash Triggered");
            StartCoroutine(FlashRoutine());
        }
    }

    IEnumerator FlashRoutine()
    {
        if (spriteRenderers == null || spriteRenderers.Count == 0)
        {
            yield break;
        }

        if (flashCycleLength <= 0f)
        {
            yield break;
        }

        int cycles = Mathf.CeilToInt(flashingDuration / flashCycleLength);
        for (int i = 0; i < cycles; i++)
        {
            // Set all to flash color
            for (int j = 0; j < spriteRenderers.Count; j++)
            {
                var sr = spriteRenderers[j];
                if (sr != null)
                {
                    sr.color = flashColor;
                }
            }

            yield return new WaitForSeconds(flashCycleLength);

            // Revert all to their original colors
            for (int j = 0; j < spriteRenderers.Count; j++)
            {
                var sr = spriteRenderers[j];
                if (sr != null && j < originalColors.Count)
                {
                    sr.color = originalColors[j];
                }
            }
        }
    }
}