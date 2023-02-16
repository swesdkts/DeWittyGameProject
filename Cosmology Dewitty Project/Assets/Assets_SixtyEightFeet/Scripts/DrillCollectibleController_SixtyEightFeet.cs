using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillCollectibleController_SixtyEightFeet : MonoBehaviour
{
    DropoffPointController_SixtyEightFeet dropOffPointScript;

    void Awake()
    {
        dropOffPointScript = GameObject.FindGameObjectWithTag("Dropoff Point").GetComponent<DropoffPointController_SixtyEightFeet>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            dropOffPointScript.partsCollected += 1;
            dropOffPointScript.UpdateDrillPartsText();
        }
    }
}
