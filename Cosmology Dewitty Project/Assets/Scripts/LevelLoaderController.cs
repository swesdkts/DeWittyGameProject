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

    // Update is called once per frame
    void Update()
    {
        RestartScene();
        ExitApplication();
    }

    /* An IEnumerator for loading scenes with the crossfade animation. 
    When starting the coroutine, put the name of the scene you want to transition to as a string inside the parentheses.

    Example: StartCoroutine(LoadScene("SampleScene")); */
    public IEnumerator LoadScene(string nextScene)
    {
        animator.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene.ToString());
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(LoadScene("SampleScene"));
        }
    }

    private void ExitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
