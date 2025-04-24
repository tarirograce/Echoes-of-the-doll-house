//written by Tariro Grace
using UnityEngine;

public class CameraBob : MonoBehaviour
{
    public CharacterController player; // Drag your player here
    public float bobSpeed = 6f;        // How fast the bobbing happens
    public float bobAmount = 0.05f;    // How high/low the camera moves

    private float defaultY;
    private float timer;

    void Start()
    {
        defaultY = transform.localPosition.y; // Save starting Y position
    }

    void Update()
    {
        if (player.isGrounded && player.velocity.magnitude > 0.2f)
        {
            // Walking: Apply bobbing effect
            timer += Time.deltaTime * bobSpeed;
            float newY = defaultY + Mathf.Sin(timer) * bobAmount;
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
        }
        else
        {
            // Not moving: reset to default position
            timer = 0f;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultY, transform.localPosition.z);
        }
    }
}
