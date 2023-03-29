using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessDialogue : MonoBehaviour
{
    public TextAsset inkJson;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        inkJson = new TextAsset (inkJson.text);
    }
}
