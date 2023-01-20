using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class PauseMenuController : MonoBehaviour
{
    public bool needMouseAccess;

    #region Object Information Overlay
    public Canvas pauseMenu;
    public Slider slider;

    public bool pauseMenuDeployed = false;

    public GameObject player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (pauseMenu != null)
        {
            HideObjectInfoOverlay();
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
        #region Show Object Info Overlay if it Exists
        if (pauseMenu)
        {
            if (pauseMenuDeployed)
            {
                HideObjectInfoOverlay();
                return;
            }

            if (!pauseMenuDeployed)
            {
                DeployObjectInfoOverlay();
            }
        }
        #endregion
    }

    public void DeployObjectInfoOverlay()
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

    public void HideObjectInfoOverlay()
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
        print(slider.value);
    }
}
