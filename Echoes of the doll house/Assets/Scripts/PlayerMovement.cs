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
    [SerializeField] float jumpHeight = 2f;          // Jump height
    [SerializeField] float gravity = -9.81f;         // Gravity force
    [SerializeField] float groundCheckDistance = 0.3f; // Adjusted ground check distance

    private CharacterController controller;
    private Vector3 velocity;  // Stores velocity (jump force & gravity)
    private bool isGrounded;   // Checks if player is grounded

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");

        controller = GetComponent<CharacterController>();  // Get CharacterController
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundStatus();  // Check if the player is on the ground
        MovePlayer();
        Jump();
        ApplyGravity();
    }

    // Check if the player is on the ground properly
    void CheckGroundStatus()
    {
        // Raycast now starts from the bottom of the character controller (fixes floating)
        Vector3 groundCheckPosition = transform.position + Vector3.down * (controller.height / 2);
        isGrounded = Physics.Raycast(groundCheckPosition, Vector3.down, groundCheckDistance);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keeps player grounded
        }
    }

    // Player movement logic
    void MovePlayer()
    {
        // Read movement input
        Vector2 direction = moveAction.ReadValue<Vector2>();

        // Convert movement direction to world space
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        moveDirection = transform.TransformDirection(moveDirection);

        // Move the player using CharacterController
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    // Jump functionality
    void Jump()
    {
        // If jump button (spacebar) is pressed and the player is grounded, apply jump force
        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump calculation
        }
    }

    // Apply gravity and move the player vertically
    void ApplyGravity()
    {
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime; // Gravity application
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
