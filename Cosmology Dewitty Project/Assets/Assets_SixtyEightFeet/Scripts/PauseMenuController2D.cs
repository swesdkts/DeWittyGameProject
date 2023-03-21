using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController2D : MonoBehaviour
{
    #region Overlay Information
    public Canvas pauseMenu;
    GameObject player;

    public bool pauseMenuDeployed = false;
    #endregion

    void Awake()
    {
        Time.timeScale = 1;
    }

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
        if ((player.GetComponent<PlayerController2D>().allowMove) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            TryInteract();
        }
    }

    public void TryInteract(string customizedInteraction = "default")
    {
        #region Show Overlay if it Exists
        if (pauseMenu)
        {
            if (pauseMenu.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "Showing" || pauseMenu.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "Hiding")
            {
                if (pauseMenuDeployed)
                {
                    StartCoroutine(HideOverlay(customizedInteraction));
                    return;
                }

                if (!pauseMenuDeployed)
                {
                    DeployOverlay();
                }
            }
        }
        #endregion
    }

    public void DeployOverlay()
    {
        Time.timeScale = 0;

        // Shows the canvas to the player and allows the "Show" animation to play.
        pauseMenu.enabled = true;
        pauseMenu.GetComponent<Animator>().SetBool("Showing", true);

        pauseMenuDeployed = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /* Allows the parameter in the TryInteract() function to be passed to this coroutine. 
       Leave the argument blank for its default running sequence when starting the coroutine. */
    public IEnumerator HideOverlay(string customizedInteraction = "default")
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Allows the "Hide" animation to play and waits roughly until it's done playing.
        pauseMenu.GetComponent<Animator>().SetBool("Showing", false);
        yield return new WaitForSecondsRealtime(0.63f);
        pauseMenu.enabled = false;
        pauseMenuDeployed = false;

        if (customizedInteraction != "exitingScene")
        {
            Time.timeScale = 1;
        }
    }
}
