using UnityEngine;

public class Collector : MonoBehaviour
{
    public void AddItem(int index)
    {
        if (index < 0 || index > 2)
            return;
        
        GameManager.Instance.AddItem(index);
    }

    public void RemoveItem(int index)
    {
        if (index < 0 || index > 2) 
            return;
        
        GameManager.Instance.RemoveItem(index);
    }

    public bool CheckInInventory(int index)
    {
        return GameManager.Instance.CheckItem(index);
    }
}