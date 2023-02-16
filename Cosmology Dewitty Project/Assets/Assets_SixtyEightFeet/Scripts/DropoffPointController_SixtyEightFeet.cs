using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropoffPointController_SixtyEightFeet : MonoBehaviour
{
    public GameObject[] drillCollectibles;
    public GameObject[] drillParts;
    public int partsCollected = 0;

    public TextMeshProUGUI drillPartsText;

    void Awake()
    {
        // Hides the drill parts when the game is ran.
        for (int i = 0; i < drillParts.Length; i++)
        {
            drillParts[i].SetActive(false);
        }

        UpdateDrillPartsText();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < drillCollectibles.Length; i++)
            {
                // If the collectible object is destroyed, show the drill part with the corresponding array index.
                if (drillCollectibles[i] == null)
                {
                    drillParts[i].SetActive(true);
                }
            }
        }
    }

    public void UpdateDrillPartsText()
    {
        drillPartsText.text = partsCollected.ToString() + "/" + drillCollectibles.Length.ToString() + " parts collected";
    }
}
