using System;
using UnityEngine;
using UnityEngine.UI;

public class ActivateUIQuestion : MonoBehaviour
{
    Vector3 _mousePosition;
    private Image _image;
    private Ray _ray;
    RaycastHit _hit;

    private void Start()
    {
        _image = gameObject.GetComponent<Image>();
    }

    void FixedUpdate()
    {
        _image.enabled = false;
        
        _mousePosition = Input.mousePosition;
        _ray = UnityEngine.Camera.main.ScreenPointToRay(_mousePosition);
        Physics.Raycast(_ray, out _hit, 1000);
        if (_hit.transform != null && _hit.transform.gameObject.CompareTag("Interactable"))
        {
            DrawCircle();
        }
    }

    private void DrawCircle()
    {
        _image.enabled = true;
        transform.position = new Vector3(_mousePosition.x + 20, _mousePosition.y + 20, 0);
    }
}
