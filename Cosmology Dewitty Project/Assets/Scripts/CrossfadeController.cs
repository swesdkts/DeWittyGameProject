using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeController : MonoBehaviour
{
    private Animator animator;
    private PauseMenuController3D pauseMenu3D;
    private PauseMenuController2D pauseMenu2D;

    public float waitTime; // Default is 1

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pauseMenu3D = GameObject.FindGameObjectWithTag("Player").GetComponent<PauseMenuController3D>();
        pauseMenu2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PauseMenuController2D>();
    }

    /* An IEnumerator for loading scenes with the crossfade animation. 
    When starting the coroutine, put the name of the scene you want to transition to as a string inside the parentheses.

    Example: StartCoroutine(LoadSceneCoroutine(SceneBuildIndex)); */
    public IEnumerator LoadSceneCoroutine(int nextScene)
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSecondsRealtime(waitTime);
        SceneManager.LoadScene(nextScene);
    }

    public void LoadScene(int nextScene)
    {
        StartCoroutine(LoadSceneCoroutine(nextScene));
    }


    public IEnumerator ExitGameCoroutine()
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSecondsRealtime(1);
        Application.Quit();
    }


    public void ResetScene()
    {
        //Time.timeScale = 1;
        StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().buildIndex));

        if (pauseMenu3D != null)
        {
            pauseMenu3D.TryInteract("exitingScene");
            return;
        }
        else if (pauseMenu2D != null)
        {
            pauseMenu2D.TryInteract("exitingScene");
        }
        
    }

    public void ExitToMuseum()
    {
        //Time.timeScale = 1;
        StartCoroutine(LoadSceneCoroutine(0));

        if (pauseMenu3D != null)
        {
            pauseMenu3D.TryInteract("exitingScene");
            return;
        }
        else if (pauseMenu2D != null)
        {
            pauseMenu2D.TryInteract("exitingScene");
        }
    }

    public void ExitGame()
    {
        //Time.timeScale = 1;
        StartCoroutine(ExitGameCoroutine());

        if (pauseMenu3D != null)
        {
            pauseMenu3D.TryInteract("exitingScene");
            return;
        }
        else if (pauseMenu2D != null)
        {
            pauseMenu2D.TryInteract("exitingScene");
        }
    }
}
