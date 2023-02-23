using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour
{
    GameObject crossfade;
    public int sceneBuildIndexToLoad;

    ObjectInteract objInteract;
    [SerializeField] bool canTeleport;

    [SerializeField] ParticleSystem teleportParticles;

    private void Awake()
    {
        objInteract = GetComponent<ObjectInteract>();
        crossfade = GameObject.FindGameObjectWithTag("Crossfade");
    }

    public void TeleportTo()
    {
        if (objInteract.switchSceneAfterInteract && canTeleport)
        {
            teleportParticles.Play();
            crossfade.GetComponent<LevelLoaderController>().LoadSceneCoroutine(sceneBuildIndexToLoad);
        }
    }

}

