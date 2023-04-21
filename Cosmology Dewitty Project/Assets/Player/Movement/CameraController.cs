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
    public float mouseSensitivity; // Default is 4
    float xRotation = 0f;

    [HideInInspector] public bool allowRotate = true;
    #endregion

    public AudioSource footLift;
    public AudioSource footStep;

    void Awake()
    {
        // Gets the transform position of the Player, which is the parent object.
        playerBody = transform.parent;

        // Gets controls and locks cursor.
        controls = new InputMaster();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (allowRotate)
        {
            Look();
        }
    }

    void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float horizontalMouse = mouseLook.x * mouseSensitivity * Time.fixedDeltaTime;
        float verticalMouse = mouseLook.y * mouseSensitivity * Time.fixedDeltaTime;

        xRotation -= verticalMouse;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * horizontalMouse);
    }

    public void PlayFootLiftSound()
    {
        footLift.Play();
    }

    public void PlayFootStepSound()
    {
        footStep.Play();
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
