using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool CanInteract;
    
    // Inventory Work
    public int indexOfItem;
    protected Collector Collector;
    [SerializeField] protected bool needItem;
    
    // Dialogue Work
    public DialogueTrigger dialogueTrigger;
    public string[] canNotInteract;
    public string[] getAccess;
    [SerializeField] private bool haveDialog;

    // Sprite Work
    protected SpriteRenderer Sr;
    public Sprite[] sprites = new Sprite[2];
    
    protected virtual void Start()
    {
        Collector = GameObject.FindWithTag("Player").GetComponent<Collector>();
        Sr = GetComponent<SpriteRenderer>();
        Sr.sprite = sprites[0];
    }
    
    protected virtual void OnMouseDown()
    {
        switch (needItem)
        {
            case true when haveDialog && !Collector.CheckInInventory(indexOfItem) && !CanInteract:
                dialogueTrigger.StartDialogue(canNotInteract);
                return;
            case true when Collector.CheckInInventory(indexOfItem):
            {
                ChangeState();
                Collector.RemoveItem(indexOfItem);

                if (!haveDialog)
                    return;
            
                DoActionImmediately();
                dialogueTrigger.StartDialogue(getAccess);
                return;
            }
            default:
                Interact();
                break;
        }
    }
    
    protected void Interact()
    {
        if (!CanInteract)
            return;
        
        DoAction();
    }

    protected virtual void DoAction()
    {
    }

    protected virtual void DoActionImmediately()
    {
        
    }

    protected virtual void ChangeState()
    {
        Sr.sprite = sprites[1];
        CanInteract = true;
    }
}
