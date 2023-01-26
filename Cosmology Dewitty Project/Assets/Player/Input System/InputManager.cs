using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController movement;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    [SerializeField] CameraController cameraController;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        // Vector2 targetMouseDelta = groundMovement.NewMouse.ReadValue<Vector2>() * Time.smoothDeltaTime;

        movement.ReceiveInput(horizontalInput);

        cameraController.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}
