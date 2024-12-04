using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float mouseSensitivity = 100f;

    private Rigidbody rb;
    private float xRotation = 0f; // Vertical rotation for the camera
    public Transform playerCamera; // Drag the Main Camera here in the Inspector

    private bool isSpeedBoosted = false; // Flag to track if speed boost is active
    private float originalSpeed; // Store the original speed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = speed; // Save the original speed value

        // Lock the cursor for mouse control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Handle player rotation (mouse look)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate the camera
        transform.Rotate(Vector3.up * mouseX); // Rotate the player horizontally

        // WASD movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z); // Apply movement
    }

    void FixedUpdate()
    {
        // Jumping logic
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Check if the player is grounded using a raycast
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    // Method to apply the speed boost
    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        if (!isSpeedBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine(boostAmount, duration));
        }
    }

    private IEnumerator SpeedBoostCoroutine(float boostAmount, float duration)
    {
        isSpeedBoosted = true;
        speed += boostAmount; // Increase speed
        Debug.Log($"Speed boosted to {speed} for {duration} seconds.");
        yield return new WaitForSeconds(duration);
        speed = originalSpeed; // Reset to original speed
        isSpeedBoosted = false;
        Debug.Log("Speed boost ended.");
    }
}
