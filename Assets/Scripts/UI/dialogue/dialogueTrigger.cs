using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct DialogueIndex
{
    public string speakerID;
    public string text;

}

public class dialogueTrigger : MonoBehaviour
{
    public List<DialogueIndex> dialogue = new List<DialogueIndex>();

    void Start()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (sr != null) { sr.enabled =false; }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            transform.parent.GetComponent<SpriteSpeakerIndex>().StartDialogue(dialogue);
        }
    }
}
