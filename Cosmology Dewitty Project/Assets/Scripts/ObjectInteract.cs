using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class ObjectInteract : MonoBehaviour
{
    #region Press To Interact Overlay Canvas
    [SerializeField] Canvas pressToInteractOverlayCanvas;

    public bool pressToInteractOverlayDeployed = false;
    #endregion

    public bool playerInRange = false;

    #region Object Information Overlay
    public Canvas objectInfoOverlayCanvas;

    public bool objectInfoOverlayDeployed = false;
    #endregion

    #region Particle System To Be Triggered (If it exists)
    public ParticleSystem particleSystemToTrigger;

    public void PlayParticles()
    {
        particleSystemToTrigger.Play();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        pressToInteractOverlayCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
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

            if (playerInRange && !objectInfoOverlayDeployed)
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
    }

    public void HideObjectInfoOverlay()
    {
        objectInfoOverlayCanvas.enabled = false;

        objectInfoOverlayDeployed = false;

        if (playerInRange)
        {
            DeployPressToInteractOverlay();
        }
    }

}
