using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 2f; 
    [SerializeField] private float minSize = 2f; 
    [SerializeField] private float maxSize = 10f; 
    [SerializeField] private float minFov = 30f; 
    [SerializeField] private float maxFov = 90f; 

    private Camera mainCamera;
    private InputAction zoomAction;

    private void Awake()
    {
        mainCamera = Camera.main; 
        zoomAction = new Actions().camera.zoom; 
    }

    private void OnEnable()
    {
        zoomAction.Enable(); 
    }

    private void OnDisable()
    {
        zoomAction.Disable(); 
    }

    private void Update()
    {
        
        float zoomDelta = zoomAction.ReadValue<float>();

        
        if (mainCamera.orthographic)
        {
            
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - zoomDelta * zoomSpeed, minSize, maxSize);
        }
        else
        {
            
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView - zoomDelta * zoomSpeed, minFov, maxFov);
        }
    }
}
