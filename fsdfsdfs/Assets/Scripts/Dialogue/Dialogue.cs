using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    private string[] _dialogue;
    public float textSpeed;

    private int _index;

    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Image>().enabled)
        {
            if (textComponent.text == _dialogue[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = _dialogue[_index];
            }
        }
    }

    public void StartDialogue(string[] dialogue)
    {
        gameObject.GetComponent<Image>().enabled = true;
        GameManager.PlayerInstance.GetComponent<Player>().canMove = false;

        _dialogue = dialogue;
        _index = 0;
        textComponent.text = String.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _dialogue[_index])
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (_index < _dialogue.Length - 1)
        {
            _index++;
            textComponent.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
            GameManager.PlayerInstance.GetComponent<Player>().canMove = true;
            textComponent.text = String.Empty;
        }
    }
}
