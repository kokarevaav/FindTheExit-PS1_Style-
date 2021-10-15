using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueManager;

    private void Start()
    {
        dialogueManager = GameObject.FindWithTag("Canvas").GetComponentInChildren<Dialogue>();
    }
    
    public void StartDialogue(string[] dialogue)
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
