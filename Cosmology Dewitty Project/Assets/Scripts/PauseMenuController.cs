using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public bool needMouseAccess;

    #region Overlay Information
    public Canvas pauseMenu;
    public Slider slider;
    public TextMeshProUGUI sensitivityText;

    public bool pauseMenuDeployed = false;

    GameObject player;
    public GameObject playerCamera;
    [SerializeField]
    ObjectInteract objectInteractScript;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (pauseMenu != null)
        {
            HideOverlay();
        }

        slider.value = playerCamera.GetComponent<CameraController>().mouseSensitivity;
        sensitivityText.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.GetComponent<PlayerController>().allowMove) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            TryInteract();
        }

        slider.value = Mathf.Round(slider.value * 10)/10;
    }

    private void TryInteract()
    {
        #region Show Overlay if it Exists
        if (pauseMenu)
        {
            if (pauseMenuDeployed)
            {
                Time.timeScale = 1;
                HideOverlay();
                return;
            }

            if (!pauseMenuDeployed)
            {
                DeployOverlay();
                Time.timeScale = 0;
            }
        }
        #endregion
    }

    public void DeployOverlay()
    {
        pauseMenu.enabled = true;

        pauseMenuDeployed = true;

        if (needMouseAccess == true)
        {
            playerCamera.GetComponent<CameraController>().allowRotate = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void HideOverlay()
    {
        pauseMenu.enabled = false;

        pauseMenuDeployed = false;

        if (needMouseAccess == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerCamera.GetComponent<CameraController>().allowRotate = true;
        }
    }

    public void updateSensitivity(float value)
    {
        playerCamera.GetComponent<CameraController>().mouseSensitivity = slider.value;
        sensitivityText.text = slider.value.ToString();
    }
}