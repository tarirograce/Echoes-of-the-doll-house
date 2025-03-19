//written by Tariro Grace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float mouseSensitivity = 2.0f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player's body for rotation
    private float xRotation = 0f; // To limit vertical rotation

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera up/down (limit vertical rotation to avoid flipping)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Keep it between -90 and 90 degrees
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player left/right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}


