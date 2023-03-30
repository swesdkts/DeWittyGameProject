using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiecePickupController : MonoBehaviour
{
    public GameObject missingPiece;

    void Start()
    {
        missingPiece.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            missingPiece.gameObject.SetActive(true);
        }
    }
}
