using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    [SerializeField] GameObject bellInfo;
    [SerializeField] GameObject shovelInfo;
    public bool hasBell;
    public bool hasShovel;

    private void Awake()
    {
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

    public void AddToInv()
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
    }

}
