using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Attributes

    [Header("\t--- Mouse Sensivity")]
    public float mouseSensivity;
    public Transform target;

    [Header("\t--- Camera Zoom")]
    public float currentZoom;
    public float minZoom;
    public float maxZoom;
    public float zoomSpeed;

    [Header("\t--- Rotation angle variables")]
    float yaw; // Y axis rotation
    float pitch; // X axis rotation

    [Header("\t--- Max angle rotation")]
    public Vector2 pitchMinMax;

    [Header("\t--- Camera Smoothing")]
    public float rotationSmoothTime;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    #endregion


    #region Update functions

    void Update()
    {
        zoomControl();
    }

    void LateUpdate()
    {
        // Camera rotation angles
        yaw += Input.GetAxis("Mouse X") * mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        // Stocks current camera rotation
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        Vector3 targetRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = currentRotation;

        // Stick the camera to the target focus (the player)
        transform.position = target.position - (transform.forward * currentZoom);
    }

    #endregion


    #region Camera controls

    // Controls the camera zoom thanks to the mouse's scrollwheel
    void zoomControl()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    #endregion
}