// Written by Swornashabi
// 3/19/2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] float speed = 5f;               // Walking speed
    [SerializeField] float jumpHeight = 2f;           // Jump height
    [SerializeField] float gravity = -9.81f;          // Gravity force
    [SerializeField] float groundCheckDistance = 0.2f; // Ground check distance to detect when player is on the ground

    private CharacterController controller;
    private Vector3 velocity;  // To store velocity (including jump force and gravity)
    private bool isGrounded;   // To check if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        controller = GetComponent<CharacterController>();  // Get the CharacterController component
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
        ApplyGravity();
    }

    // Player movement
    void MovePlayer()
    {
        // Read movement input
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // Convert the movement direction from local space to world space
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        moveDirection = transform.TransformDirection(moveDirection); // Convert to world space

        // Move the player using CharacterController
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    // Jump functionality
    void Jump()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to keep player grounded
        }

        // If jump button (spacebar) is pressed and the player is grounded, apply jump force
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate the jump velocity
        }
    }

    // Apply gravity and move the player vertically
    void ApplyGravity()
    {
        // Apply gravity if the player is not grounded
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Move the player with the current velocity
        controller.Move(velocity * Time.deltaTime);
    }
}



