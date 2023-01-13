using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    Rigidbody playerRb;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0,0,translation);
    }
}
