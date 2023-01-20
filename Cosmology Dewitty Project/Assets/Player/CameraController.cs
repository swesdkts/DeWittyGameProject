using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX, mouseY;

    void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
