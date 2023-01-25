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
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu != null)
        {
            HideOverlay();
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        #region Show Overlay if it Exists
        if (pauseMenu)
        {
            if (pauseMenuDeployed)
            {
                HideOverlay();
                return;
            }

            if (!pauseMenuDeployed)
            {
                DeployOverlay();
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
            gameObject.GetComponent<CameraController>().allowRotate = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HideOverlay()
    {
        pauseMenu.enabled = false;

        pauseMenuDeployed = false;

        if (needMouseAccess == true)
        {
            gameObject.GetComponent<CameraController>().allowRotate = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void updateSensitivity(float value)
    {
        gameObject.GetComponent<CameraController>().sensitivity = slider.value;
        gameObject.GetComponent<CameraController>().updateCameraSensitivity();
        sensitivityText.text = slider.value.ToString();
    }
}
