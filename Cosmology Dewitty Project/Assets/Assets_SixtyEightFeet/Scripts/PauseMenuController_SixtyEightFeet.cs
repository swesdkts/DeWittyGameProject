using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController_SixtyEightFeet : MonoBehaviour
{
    public bool needMouseAccess;

    #region Overlay Information
    public Canvas pauseMenu;
    GameObject player;

    public bool pauseMenuDeployed = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (pauseMenu != null)
        {
            HideOverlay();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.GetComponent<PlayerController_SixtyEightFeet>().allowMove) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            TryInteract();
        }
    }

    public void TryInteract()
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
        }
    }
}
