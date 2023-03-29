using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    ObjectInteract objInter;

    private void Start()
    {
        objInter = FindObjectOfType<ObjectInteract>();
    }

    private void Update()
    {
        //DisplayDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

   /* void DisplayDialogue()
    {
        if (objInter.hasDialogue && objInter.objectInfoOverlayDeployed && objInter.playerInRange)
        {
            TriggerDialogue();
            objInter.hasDialogue= false;
        }
    }*/

}
