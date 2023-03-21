using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;

    public float speed;
    public bool allowMove = true;

    void Awake()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMove)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.transform.position = new Vector2((transform.position.x + (moveInput.normalized.x * speed * Time.deltaTime)), (transform.position.y + (moveInput.normalized.y * speed * Time.deltaTime)));
        }
    }
}
