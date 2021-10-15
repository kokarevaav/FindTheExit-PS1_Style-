using UnityEngine;

public class DoorOpener : Interactable
{
    public GameObject door;
    protected override void DoActionImmediately()
    {
        door.GetComponent<InteractableDialog>().enabled = false;
        door.GetComponent<DialogueTrigger>().enabled = false;
        door.GetComponent<Door>().enabled = true;
    }
}
