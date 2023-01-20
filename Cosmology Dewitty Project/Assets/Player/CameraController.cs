using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1;
    float sensitivityX = 4.5f;
    float sensitivityY = 0.005625f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    public bool allowRotate = true;

    void Start()
    {
        sensitivityX = sensitivityX * sensitivity;
        sensitivityY = sensitivityY * sensitivity;
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

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
