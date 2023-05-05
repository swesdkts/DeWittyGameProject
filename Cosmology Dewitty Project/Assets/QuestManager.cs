using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] GameObject bellGameobj;
    [SerializeField] GameObject shovelGameobj;
    [SerializeField] GameObject artifactGameobj;

    // Start is called before the first frame update
    void Start()
    {
        bellGameobj.SetActive(false);
        shovelGameobj.SetActive(false);
        artifactGameobj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBellQuest()
    {
        if(bellGameobj!= null)
        {
            bellGameobj.SetActive(true);
        }
        
    }

    public void StartArtifact()
    {
        if(artifactGameobj != null)
        {
            artifactGameobj.SetActive(true);
        }
    }

    public void StartShovelQuest()
    {
        if(shovelGameobj!= null)
        {
            shovelGameobj.SetActive(true);
        }
    }
}
