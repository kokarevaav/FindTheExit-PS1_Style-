using UnityEditor.Animations;
using UnityEngine;

public class ChangeOutfit : MonoBehaviour
{
    [SerializeField] private AnimatorController toController;

    public void ChangePlayerOutfit()
    {
        GameManager.PlayerInstance.GetComponent<Player>().ChangeAnimatorController(toController);
    }
}
