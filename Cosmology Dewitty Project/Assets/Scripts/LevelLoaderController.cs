using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    /* An IEnumerator for loading scenes with the crossfade animation. 
    When starting the coroutine, put the name of the scene you want to transition to as a string inside the parentheses.

    Example: StartCoroutine(LoadScene("SampleScene")); */
    public IEnumerator LoadSceneCoroutine(string nextScene)
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene.ToString());
    }

    public IEnumerator ExitGameCoroutine()
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

    // A function for quitting the application. This is needed in order for the menu's exit button to work.
    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }

    public void ResetScene()
    {
        StartCoroutine(LoadSceneCoroutine("SampleScene"));
    }

}
