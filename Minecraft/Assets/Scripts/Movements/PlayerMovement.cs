using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // The following camera of the player
    public Transform followingCamera;
    // Movements attributes
    public float speed = 0.1f;
    public float mouseSensitivity = 2.0f;
    // Jumping attributes
    public bool isGrounded;
    public float jumpForce = 5.0f;

    // The rigidBody associated
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Directional and mouse input
        float directionInputV = Input.GetAxis("Vertical") * speed;
        float directionInputH = Input.GetAxis("Horizontal") * speed;
        float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseInputY = -Input.GetAxis("Mouse Y") * mouseSensitivity;
        float angleX = followingCamera.localEulerAngles.x;

        // Moving faster if shift is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }

        // Moving slower if shift is released
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }

        // Calculate movement direction based on player's rotation
        Vector3 movementDirection = transform.forward * directionInputV + transform.right * directionInputH;
        movementDirection.y = 0;

        // Moving the player
        transform.localPosition += movementDirection;

        // Rotating the player
        angleX = Math.Clamp(angleX + mouseInputY, 0f, 30f);
        followingCamera.localEulerAngles = new Vector3(angleX, followingCamera.localEulerAngles.y, followingCamera.localEulerAngles.z);
        transform.Rotate(Vector3.up * mouseInputX);

        // Jumping the player
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
