public class InteractableWithItem : Interactable
{
    // Dialogue Work
    public string[] foundItem;

    protected override void Start()
    {
        base.Start();
        CanInteract = true;
    }

    protected override void OnMouseDown()
    {
        Interact();
        dialogueTrigger.StartDialogue(foundItem);
        
        ChangeState();
    }

    protected override void DoAction()
    {
        Collector.AddItem(indexOfItem);
    }

    protected override void ChangeState()
    {
        Sr.sprite = sprites[1];
    }
}
