using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputMaster controls;

    #region Camera Rotation Information
    Vector2 mouseLook;
    Transform playerBody;
    public float mouseSensitivity = 4.5f;
    float xRotation = 0f;

    public bool allowRotate = true;
    #endregion

    void Awake()
    {
        // Gets the transform position of the Player, which is the parent object.
        playerBody = transform.parent;

        // Gets controls and locks cursor.
        controls = new InputMaster();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (allowRotate)
        {
            Look();
        }
    }

    void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float horizontalMouse = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float verticalMouse = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= verticalMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * horizontalMouse);
    }


    #region On Enable/Disable
    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
    #endregion
}
