using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
    ObjectInteract picturePlaceholder;

    public GameObject rewardObjects;
    public GameObject puzzleObjects;

    public GameObject pictureBlankFrame;
    public GameObject pictureFilled;

    public int totalPieces = 0;
    public int placedCount = 0;

    void Awake()
    {
        pictureBlankFrame.SetActive(true);
        puzzleObjects.SetActive(true);
        pictureFilled.SetActive(false);
        rewardObjects.SetActive(false);

        picturePlaceholder = GameObject.Find("Picture Placeholder").GetComponent<ObjectInteract>();
    }

    void Update()
    {
        if (placedCount == totalPieces)
        {
            pictureFilled.SetActive(true);
            rewardObjects.SetActive(true);
            puzzleObjects.SetActive(false);

            picturePlaceholder.needsPlayerAccess = false;
            picturePlaceholder.playerCamera.GetComponent<CameraController>().allowRotate = true;
            picturePlaceholder.player.GetComponent<PlayerController>().allowMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void IncreasePlacedPieces()
    {
        placedCount++;
    }

}
