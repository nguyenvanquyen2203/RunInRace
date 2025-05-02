using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        Vector2 input = InputManager.Instance.GetMouseInput();
        float mouseX = input.x;
        float mouseY = input.y;
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(Vector3.right * xRotation);
        transform.Rotate(mouseX * Time.deltaTime * Vector3.up * xSensitivity);
    }
}
