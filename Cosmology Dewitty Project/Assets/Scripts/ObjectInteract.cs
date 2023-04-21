using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteract : MonoBehaviour
{
    #region Press To Interact Overlay Canvas
    [Header("Interaction")]
    [SerializeField] Canvas pressToInteractOverlayCanvas;
    [HideInInspector] public bool pressToInteractOverlayDeployed = false;
    #endregion

    #region Switch scene after interact
    [HideInInspector] public bool playerInRange = false;
    [Space(5)] public ParticleSystem particleSystemToTrigger;
    [SerializeField] public bool switchSceneAfterInteract = false;
    SwitchScene switchSceneCS;
    #endregion

    #region Player and Mouse
    [Header("Player Access")]
    public GameObject player;
    public GameObject playerCamera;
    #endregion

    public bool canPickUp = false;
    
    public bool hasDialogue = false;

    #region Object Information Overlay
    [Header("Object Info Overlay (If Needed)")]
    public Canvas objectInfoOverlayCanvas;

    [HideInInspector] public bool objectInfoOverlayDeployed = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switchSceneCS = GetComponent<SwitchScene>();
        player = GameObject.Find("Player");
        playerCamera = GameObject.Find("Player Camera");

        if (objectInfoOverlayCanvas != null)
        {
            HideObjectInfoOverlay();
        }
        HidePressToInteractOverlay();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) || (Input.GetKeyDown(KeyCode.Escape)) && objectInfoOverlayDeployed)
        {
            if (player.GetComponent<PauseMenuController3D>().pauseMenuDeployed == false)
            {
                if(canPickUp && playerInRange)
                {
                    PickUpObject();
                }
                else
                {
                    TryInteract();
                    if (switchSceneAfterInteract && playerInRange)
                    {
                        switchSceneCS.TeleportTo();
                    }
                }
            }
        }
    }

    private void TryInteract()
    {
        #region Show Object Info Overlay if it Exists
        if (objectInfoOverlayCanvas)
        {
            if (objectInfoOverlayDeployed)
            {
                HideObjectInfoOverlay();
                return;
            }

            if ((playerInRange && !objectInfoOverlayDeployed))
            {
                DeployObjectInfoOverlay();
            }
        }
        #endregion

        #region Play Particle System if it Exists
        if (particleSystemToTrigger)
        {
            if (playerInRange)
            {
                particleSystemToTrigger.Play();
            }
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeployPressToInteractOverlay();
            playerInRange = true;
            if (hasDialogue && playerInRange)
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        HidePressToInteractOverlay();
        
        if (objectInfoOverlayCanvas)
        {
            HideObjectInfoOverlay();
        }
    }

    public void DeployPressToInteractOverlay()
    {
        pressToInteractOverlayCanvas.enabled = true;

        pressToInteractOverlayDeployed = true;
    }

    public void HidePressToInteractOverlay()
    {
        pressToInteractOverlayCanvas.enabled = false;

        pressToInteractOverlayDeployed = false;
    }

    public void DeployObjectInfoOverlay()
    {
        HidePressToInteractOverlay();
        objectInfoOverlayCanvas.enabled = true;

        objectInfoOverlayDeployed = true;

        playerCamera.GetComponent<CameraController>().allowRotate = false;
        player.GetComponent<PlayerController>().allowMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideObjectInfoOverlay()
    {
        objectInfoOverlayCanvas.enabled = false;

        objectInfoOverlayDeployed = false;

        if (playerInRange)
        {
            DeployPressToInteractOverlay();
        }

        playerCamera.GetComponent<CameraController>().allowRotate = true;
        player.GetComponent<PlayerController>().allowMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PlayParticles()
    {
        particleSystemToTrigger.Play();
    }

    public void PickUpObject()
    {
        InventoryTest inventoryTest;
        inventoryTest = FindObjectOfType<InventoryTest>();
        if (CompareTag("Bell"))
        {
            inventoryTest.AddBell();
            Destroy(gameObject);
        }
        
        if (CompareTag("Shovel"))
        {
            inventoryTest.AddShovel();
            Destroy(gameObject);
        }
        
        HidePressToInteractOverlay();
    }

}
