using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] float waitTime = 2.5f;
    [SerializeField] int sceneToLoadIndex;

    ObjectInteract objInteract;
    [SerializeField] bool canTeleport;

    private void Awake()
    {
        objInteract = GetComponent<ObjectInteract>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneToLoadIndex);
    }

    public void TeleportTo()
    {
        if (objInteract.switchSceneAfterInteract && canTeleport)
        {
            StartCoroutine(WaitTime());
        }
    }

}

