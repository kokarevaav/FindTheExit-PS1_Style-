using UnityEngine;
using UnityEngine.WSA;

public class CameraChanger : MonoBehaviour
{
    public string position;
    public string[] positions;
    public Animator cameraAnimator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        cameraAnimator.SetFloat(position, 1f);
        cameraAnimator.SetFloat(positions[0], 0f);
        cameraAnimator.SetFloat(positions[1], 0f);
    }
}
