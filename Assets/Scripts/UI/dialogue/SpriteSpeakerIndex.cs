using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public struct SpriteIndex
{
    //[TextArea(2, 6)]
    public Sprite portrait;
    public string id;

}

public class SpriteSpeakerIndex : MonoBehaviour
{
    public GameObject dialoguePanel;

    public List<SpriteIndex> spriteIndex = new List<SpriteIndex>();
    public GameObject player;

    private TMP_Text titleUI;
    private TMP_Text dialogueUI;
    private Image portraitUI;

    private List<DialogueIndex> dialogueQueue;

    public void Start()
    {
        player = Player.Instance.gameObject.transform.GetChild(0).gameObject;

        if (dialoguePanel)
        {
            if (dialoguePanel.activeSelf) { dialoguePanel.SetActive(false); }

            titleUI = dialoguePanel.transform.Find("NameAndDialogueText/Title")?.GetComponent<TMP_Text>();
            dialogueUI = dialoguePanel.transform.Find("NameAndDialogueText/Dialogue")?.GetComponent<TMP_Text>();
            portraitUI = dialoguePanel.transform.Find("Portrait")?.GetComponent<Image>();
        }
    }

    public void StartDialogue(List<DialogueIndex> dialogueList)
    {
        dialogueQueue = dialogueList;
        if (dialogueQueue != null && dialogueQueue.Count > 0)
        {
            present(dialogueList[0]);
            dialogueList.RemoveAt(0);
            dialoguePanel.SetActive(true);
            player.GetComponent<PlayerController>().dialogueActive = true;
        }
    }

    public void ContinueDialogue()
    {
        if (dialogueQueue == null || dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        present(dialogueQueue[0]);
        dialogueQueue.RemoveAt(0);
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        player.GetComponent<PlayerController>().dialogueActive = false;
    }

    public void present(DialogueIndex dialogue)
    {
        if (titleUI != null) titleUI.text = dialogue.speakerID;
        if (portraitUI != null) portraitUI.sprite = GetSpriteByID(dialogue.speakerID);
        if (dialogueUI != null) dialogueUI.text = dialogue.text;
    }

    public Sprite GetSpriteByID(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;

        foreach (var entry in spriteIndex)
        {
            if (entry.id != null && entry.id.ToLower() == id.ToLower())
            {
                return entry.portrait;
            }
        }
        return null; // Return null if no matching ID is found
    }
}