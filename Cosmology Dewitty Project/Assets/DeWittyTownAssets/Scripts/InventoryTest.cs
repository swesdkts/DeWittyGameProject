using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] GameObject bellInfo;
    [SerializeField] GameObject shovelInfo;
    [SerializeField] GameObject finalObject;
    public bool hasBell;
    public bool hasShovel;
    public bool hasArtifact;
    bool levelComplete;

    private void Awake()
    {
        finalObject.SetActive(false);
        bellInfo.SetActive(false);
        shovelInfo.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBell && hasShovel && hasArtifact)
        {
            LevelComplete();
        }
        
    }

    public void AddBell()
    {
        hasBell = true;
        bellInfo.SetActive(true);
    }

    public void AddShovel()
    {
        hasShovel = true;
        shovelInfo.SetActive(true);
    }

    public void AddArtifact()
    {
        hasArtifact = true;
    }

    void LevelComplete()
    {
        if (!levelComplete)
        {
            finalObject.SetActive(true);
            levelComplete = true;
        }

        else
        {
            return;
        }
    }

    /*public void AddToInv()
    {
        if (CompareTag("Bell"))
        {
            AddBell();
            Destroy(GameObject.FindGameObjectWithTag("Bell"));
        }

        if (CompareTag("Shovel"))
        {
            AddShovel();
            Destroy(gameObject);
        }
    }*/

}
