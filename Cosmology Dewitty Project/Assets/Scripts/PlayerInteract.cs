using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public ItemInteract itemInteract;
    public ObjectInteract objectInteract;

    // Start is called before the first frame update
    void Start()
    {
        itemInteract = FindObjectOfType<ItemInteract>();
        objectInteract = FindObjectOfType<ObjectInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && itemInteract.playerInRange)
        {
            itemInteract.PlayParticles();
        }

        if (Input.GetKeyDown(KeyCode.Q) && objectInteract.playerInRange)
        {
            objectInteract.DeployOverlay();
        }
    }
}
