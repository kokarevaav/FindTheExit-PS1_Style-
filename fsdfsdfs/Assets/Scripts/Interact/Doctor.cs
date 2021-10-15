using UnityEngine;
using UnityEngine.Serialization;

public class Doctor : InteractableWithItem
{
    private bool _isDead;
    private int _index;
    [FormerlySerializedAs("_animator")] [SerializeField] private Animator animator;
    
    private static readonly int Status = Animator.StringToHash("State");

    protected override void Start()
    {
        Collector = GameObject.FindWithTag("Player").GetComponent<Collector>();
        CanInteract = true;
        _isDead = false;
        _index = 0;
    }

    protected override void OnMouseDown()
    {
        if (!_isDead && Collector.CheckInInventory(0))
        {
            ChangeState();
            _isDead = true;
        }

        if (_isDead)
        {
            ChangeState();
            dialogueTrigger.StartDialogue(getAccess);
            Interact();
        }
    }

    protected override void DoAction()
    {
        base.DoAction();
        GameManager.PlayerInstance.GetComponent<ChangeOutfit>().ChangePlayerOutfit();
    }

    protected override void ChangeState()
    {
        _index++;
        animator.SetFloat(Status, _index);
    }
}
