using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public Image puzzleImage;

    public GameObject pictureBlankFrame;
    public GameObject pictureFilled;

    public int totalPieces = 0;
    public int placedCount = 0;

    public void Start()
    {
        pictureBlankFrame.SetActive(true);
        pictureFilled.SetActive(false);
        puzzleImage.enabled = false;
    }

    void Update()
    {
        if (placedCount == totalPieces)
        {
            pictureBlankFrame.SetActive(false);
            pictureFilled.SetActive(true);
            puzzleImage.enabled = true;
        }
    }

    public void IncreasePlacedPieces()
    {
        placedCount++;
    }

}
