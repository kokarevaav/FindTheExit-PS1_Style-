using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform kent;

    void Start()
    {
        kent = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate() 
    {
        transform.LookAt(kent);    
    }
}
