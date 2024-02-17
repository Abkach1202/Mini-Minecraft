using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    // The following camera of the player
    public Transform followingCamera;
    // Movements attributes
    public float speed;
    public float mouseSensitivity;
    // Jumping attributes
    public bool isGrounded;
    public float jumpForce;

    // The rigidBody associated
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Directional and mouse input
        float directionInputV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float directionInputH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseInputY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime   ;
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
    }

    void FixedUpdate() {
        // Directional and mouse input
        float directionInputV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float directionInputH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float mouseInputX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseInputY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime   ;
        float angleX = followingCamera.localEulerAngles.x;

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

    void OnCollisionEnter()
    {
        isGrounded = true;
    }
}
