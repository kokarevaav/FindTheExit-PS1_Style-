public class InteractableDialog : Interactable
{
    public string[] dialog;

    protected override void Start()
    {
        
    }

    protected override void OnMouseDown()
    {
        dialogueTrigger.StartDialogue(dialog);
    }
}
