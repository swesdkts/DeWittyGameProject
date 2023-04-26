using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropDownText : MonoBehaviour
{
    [SerializeField] GameObject textInformation;

    // Start is called before the first frame update
    void Start()
    {
        textInformation.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemClick()
    {
        textInformation.SetActive(true);
    }

}
