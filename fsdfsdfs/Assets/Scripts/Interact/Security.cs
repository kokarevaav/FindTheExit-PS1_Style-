using System.Collections;
using UnityEngine;

public class Security : Interactable
{
    private GameObject _endGame;
    public Animator lift;
    private static readonly int Open = Animator.StringToHash("Open");

    protected override void Start()
    {
        Collector = GameObject.FindWithTag("Player").GetComponent<Collector>();
        _endGame = GameObject.FindWithTag("EndGame");
        _endGame.SetActive(false);
    }

    protected override void OnMouseDown()
    {
        if (!Collector.CheckInInventory(indexOfItem))
        {
            dialogueTrigger.StartDialogue(canNotInteract);
            StartCoroutine(WaitForSecond(3f));
        }
        
        dialogueTrigger.StartDialogue(getAccess);
        lift.SetFloat(Open, 1f);
        StartCoroutine(WaitForSecond(3f));  
    }

    IEnumerator WaitForSecond(float sec)
    {
        yield return new WaitForSeconds(sec);
        _endGame.SetActive(true);
        Time.timeScale = 0;
    }
} 
