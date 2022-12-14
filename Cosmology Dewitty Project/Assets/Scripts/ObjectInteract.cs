using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class ObjectInteract : MonoBehaviour
{
    [SerializeField] Canvas canvasOverlay;
    [SerializeField] Image backgroundImage;
    [SerializeField] Image objectImage;
    [SerializeField] TextMeshProUGUI objectDescription;
    [SerializeField] TextMeshProUGUI interactText;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        canvasOverlay.enabled = false;
        backgroundImage.enabled = false;
        objectImage.enabled = false;
        playerInRange = false;
        objectDescription.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasOverlay.enabled = true;
            interactText.enabled = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvasOverlay.enabled = false;
        interactText.enabled = false;
        playerInRange = false;
        objectImage.enabled=false;
        objectDescription.enabled=false;
    }

    public void DeployOverlay()
    {
        canvasOverlay.enabled = true;
        backgroundImage.enabled = true;
        interactText.enabled = false;
        objectImage.enabled = true;
        objectDescription.enabled = true;
    }

}
