using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour
{
    CrossfadeController crossfade;
    public int sceneBuildIndexToLoad;

    ObjectInteract objInteract;
    [SerializeField] bool canTeleport;

    GameObject player;
    [SerializeField] ParticleSystem teleportParticles;

    private void Awake()
    {
        objInteract = GetComponent<ObjectInteract>();
        crossfade = FindObjectOfType<CrossfadeController>();
        player = GameObject.Find("Player");
        teleportParticles = player.GetComponentInChildren<ParticleSystem>();
    }

    public void TeleportTo()
    {
        if (objInteract.switchSceneAfterInteract && canTeleport)
        {
            StartCoroutine(TeleportCoroutine());
        }
    }

    // I had to create a coroutine so there would be a delay. The reason C# works this way is because it just does.
    public IEnumerator TeleportCoroutine()
    {
        if(teleportParticles != null)
        {
            teleportParticles.Play();
        }
        yield return new WaitForSeconds(1.5f);

        crossfade.LoadScene(sceneBuildIndexToLoad);
    }

    public void StartGame()
    {
        StartCoroutine(TeleportCoroutine());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

