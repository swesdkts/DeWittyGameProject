using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Sensitivity Data
    public float sensitivity = 1;
    float originalXSensitivity = 4.5f;
    float originalYSensitivity = 0.005625f;
    float sensitivityX;
    float sensitivityY;
    float mouseX, mouseY;
    #endregion

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    public bool allowRotate = true;

    void Start()
    {
        updateCameraSensitivity();
    }

    void Update()
    {
        if (allowRotate)
        {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
        }
    }

    public void updateCameraSensitivity()
    {
        sensitivityX = originalXSensitivity * sensitivity;
        sensitivityY = originalYSensitivity * sensitivity;
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
