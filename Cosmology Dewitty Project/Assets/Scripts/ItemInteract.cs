using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]

public class ItemInteract : MonoBehaviour
{
    [SerializeField] private Canvas interactCanvas;
    [SerializeField] public ParticleSystem interactedWith;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        interactCanvas.enabled = false;
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // If player is within range prompt to interact via sphere collider
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactCanvas.enabled = true;
            playerInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        interactCanvas.enabled = false;
        playerInRange = false;
    }

    public void PlayParticles()
    {
        interactedWith.Play();
    }

}
