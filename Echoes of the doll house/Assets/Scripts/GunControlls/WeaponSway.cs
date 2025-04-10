// written by Tariro Grace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float amount = 0.02f;  // The amount of sway on each axis (X, Y)
    public float maxAmount = 0.03f;  // Max limit for the sway
    public float smooth = 3.0f;  // How smoothly the sway follows the movement

    private Vector3 initialPosition;  // Store the gun's initial position (before sway)

    void Start()
    {
        initialPosition = transform.localPosition;  // Store initial position on start
    }

    void Update()
    {
        // Get mouse input for horizontal and vertical movement
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;

        // Clamp the movement to avoid excessive sway
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        // Calculate the final position of the gun based on movement
        Vector3 finalPosition = new Vector3(movementX, movementY, 0);

        // Smoothly interpolate between the gun's current position and the new swayed position
        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + finalPosition, Time.deltaTime * smooth);
    }
}

