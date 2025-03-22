//written by Tariro Grace
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform rightGunBone;
    public Transform leftGunBone;
    public Arsenal[] arsenal;
    public Transform playerCamera; // Camera for looking around
    public float speed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    private Animator animator;
    private CharacterController controller;
    private float ySpeed;

    void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        if (arsenal.Length > 0)
            SetArsenal(arsenal[0].name);
    }

    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    private void HandleMovement()
    {
        // Get input for horizontal and vertical movement
        float x = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float z = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow

        // Calculate movement direction based on camera orientation
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply gravity and jumping
        ySpeed += gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        // Apply movement and gravity
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void HandleLook()
    {
        // Use the mouse or right stick to rotate the camera for looking around
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate player horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera vertically
        playerCamera.Rotate(Vector3.left * mouseY);
    }

    public void SetArsenal(string name)
    {
        foreach (Arsenal hand in arsenal)
        {
            if (hand.name == name)
            {
                if (rightGunBone.childCount > 0)
                    Destroy(rightGunBone.GetChild(0).gameObject);
                if (leftGunBone.childCount > 0)
                    Destroy(leftGunBone.GetChild(0).gameObject);

                if (hand.rightGun != null)
                {
                    GameObject newRightGun = (GameObject)Instantiate(hand.rightGun);
                    newRightGun.transform.parent = rightGunBone;
                    newRightGun.transform.localPosition = Vector3.zero;
                    newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                }

                if (hand.leftGun != null)
                {
                    GameObject newLeftGun = (GameObject)Instantiate(hand.leftGun);
                    newLeftGun.transform.parent = leftGunBone;
                    newLeftGun.transform.localPosition = Vector3.zero;
                    newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
                }

                animator.runtimeAnimatorController = hand.controller;
                return;
            }
        }
    }

    [System.Serializable]
    public struct Arsenal
    {
        public string name;
        public GameObject rightGun;
        public GameObject leftGun;
        public RuntimeAnimatorController controller;
    }
}
