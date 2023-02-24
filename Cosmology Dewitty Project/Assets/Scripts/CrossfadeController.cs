using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeController : MonoBehaviour
{
    private Animator animator;

    [Tooltip("The usual value is 1.5")]
    public float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /* An IEnumerator for loading scenes with the crossfade animation. 
    When starting the coroutine, put the name of the scene you want to transition to as a string inside the parentheses.

    Example: StartCoroutine(LoadSceneCoroutine("SampleScene")); */
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
        Time.timeScale = 1;
        StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void ExitToMuseum()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneCoroutine(0));
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        StartCoroutine(ExitGameCoroutine());
    }
}