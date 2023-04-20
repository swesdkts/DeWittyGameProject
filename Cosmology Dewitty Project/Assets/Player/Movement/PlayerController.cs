using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]Canvas inventoryMenu;

    #region Gravity
    Vector3 velocity;
    
    [Header("Physics")]
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

    [HideInInspector] public bool allowMove = true;
    float moveSpeed = 7;
    #endregion

    void Awake()
    {
        inventoryMenu.enabled= false;
        controls = new InputMaster();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        OpenInventory();
        Gravity();

        if (allowMove)
        {
            playerMovement();
        }
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

    #region Activate/Disable Inventory Screen
    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryMenu.enabled)
            {
                inventoryMenu.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                inventoryMenu.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    #endregion
}
