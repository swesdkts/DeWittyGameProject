using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Gravity
    Vector3 velocity;
    
    public float gravity;
    #endregion

    #region Ground Checking
    public LayerMask groundMask;
    public Transform groundCheck;

    bool isGrounded;
    #endregion

    #region Movement
    InputMaster controls;
    CharacterController controller;
    Vector2 move;

    float moveSpeed = 7;
    #endregion

    void Awake()
    {
        controls = new InputMaster();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Gravity();
        playerMovement();
    }

    #region Gravity and Movement
    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        if (isGrounded)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    void playerMovement()
    {
        move = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement =  (move.x * transform.right) + (move.y * transform.forward);
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
    #endregion

    #region Enabling/Disabling Input Controls
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
