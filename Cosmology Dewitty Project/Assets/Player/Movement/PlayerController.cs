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
    [SerializeField] GameObject playerCamera;
    [HideInInspector] public bool allowViewBobbing = true;

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

            /* If the player moves and view bobbing is enabled, the view bobbing animation will play.
               NOTICE: If you're looking for the code for the foot step or foot lift sound, refer to the CameraController script.*/
            if (allowViewBobbing)
            {
                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    playerCamera.GetComponent<Animator>().SetBool("isMoving", true);
                }
                else
                {
                    playerCamera.GetComponent<Animator>().SetBool("isMoving", false);
                }
            }
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

    #region Toggling View Bobbing
    public void ToggleViewBobbing()
    {
        if (allowViewBobbing)
        {
            allowViewBobbing = false;
        }
        if (!allowViewBobbing)
        {
            allowViewBobbing = true;
        }
    }
    #endregion
}
