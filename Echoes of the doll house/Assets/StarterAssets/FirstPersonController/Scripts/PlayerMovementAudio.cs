using UnityEngine;

public class PlayerMovementAudio : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource footstepsAudio;
    public float stepDelay = 0.5f; // time between steps
    private float stepTimer;

    void Update()
    {
        // Check if player is moving and grounded
        if (controller.isGrounded && controller.velocity.magnitude > 0.2f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDelay)
            {
                footstepsAudio.Play(); // play footstep sound
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepDelay; // reset timer if not walking
        }
    }
}
