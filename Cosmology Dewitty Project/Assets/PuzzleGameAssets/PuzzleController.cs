using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    public GameObject rewardObjects;
    public GameObject puzzleObjects;

    public GameObject pictureBlankFrame;
    public GameObject pictureFilled;

    public int totalPieces = 0;
    public int placedCount = 0;

    public void Start()
    {
        pictureBlankFrame.SetActive(true);
        puzzleObjects.SetActive(true);
        pictureFilled.SetActive(false);
        rewardObjects.SetActive(false);
    }

    void Update()
    {
        if (placedCount == totalPieces)
        {
            pictureFilled.SetActive(true);
            rewardObjects.SetActive(true);
            puzzleObjects.SetActive(false);
        }
    }

    public void IncreasePlacedPieces()
    {
        placedCount++;
    }

}
