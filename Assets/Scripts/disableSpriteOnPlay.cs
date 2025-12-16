using UnityEngine;

public class disableSpriteOnPlay : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (sr != null) { sr.enabled = false; }
    }
}
