using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController3D : MonoBehaviour
{
    #region Player
    public GameObject playerCamera;
    GameObject player;
    #endregion

    #region Overlay Information
    [Header("Pause Menu UI")]
    public Canvas pauseMenu;
    public Slider slider;
    public TextMeshProUGUI sensitivityText;
    [HideInInspector] public bool pauseMenuDeployed = false;
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
            pauseMenu.enabled = false;
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

    // Call TryInteract(exitingScene); if you're managing scenes. Otherwise, just use TryInteract();
    public void TryInteract(string customizedInteraction = "default")
    {
        #region Show Overlay if it Exists
        if (pauseMenu)
        {
            // Keeps the player from breaking the animation if they spam the Escape key.
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

        playerCamera.GetComponent<CameraController>().allowRotate = false;
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
            playerCamera.GetComponent<CameraController>().allowRotate = true;
            Time.timeScale = 1;
        }
    }

    public void updateSensitivity(float value)
    {
        playerCamera.GetComponent<CameraController>().mouseSensitivity = slider.value;
        sensitivityText.text = slider.value.ToString();
    }
}
