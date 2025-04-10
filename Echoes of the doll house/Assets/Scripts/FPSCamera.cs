// Written by Tariro Grace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float mouseSensitivity = 2.0f; // Mouse sensitivity
    public Transform playerBody; // Reference to the player's body for rotation
    private float xRotation = 0f; // To limit vertical rotation
    private float yRotation = 0f; // To limit horizontal rotation
    public float rotationSmoothing = 5f; // Smoothing factor for more human-like movement

    private float maxVerticalAngle = 80f; // Max vertical angle to rotate (feel free to tweak)

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Limit and smooth vertical rotation (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxVerticalAngle, maxVerticalAngle); // Limit vertical rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Smooth the horizontal rotation (left/right)
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f); // Limit horizontal rotation to keep it more natural
        Quaternion targetRotation = Quaternion.Euler(0f, yRotation, 0f);
        playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetRotation, rotationSmoothing * Time.deltaTime);
    }
}
