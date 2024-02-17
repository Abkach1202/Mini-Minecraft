using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // The following camera of the player
  [SerializeField] private Transform PlayerCamera;

  // Movements attributes
  [SerializeField] private float PlayerSpeed;
  [SerializeField] private float PlayerMouseSensitivity;

  // Jumping attributes
  [SerializeField] private float PlayerJumpForce;
  private bool PlayerIsGrounded;

  // The rigidBody associated
  private Rigidbody PlayerRigidBody;

  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
    // Moving faster if shift is pressed
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      PlayerSpeed *= 2;
    }

    // Moving slower if shift is released
    if (Input.GetKeyUp(KeyCode.LeftShift))
    {
      PlayerSpeed /= 2;
    }
  }

  void FixedUpdate()
  {
    // Directional and mouse input
    float DirectionInputV = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
    float DirectionInputH = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
    float MouseInputX = Input.GetAxis("Mouse X") * PlayerMouseSensitivity * Time.deltaTime;
    float MouseInputY = -Input.GetAxis("Mouse Y") * PlayerMouseSensitivity * Time.deltaTime;
    float AngleX = PlayerCamera.localEulerAngles.x;

    // Calculate movement direction based on player's rotation
    Vector3 MovementDirection = transform.forward * DirectionInputV + transform.right * DirectionInputH;
    MovementDirection.y = 0;

    // Moving the player
    transform.localPosition += MovementDirection;

    // Rotating the player
    AngleX = Math.Clamp(AngleX + MouseInputY, 0f, 30f);
    PlayerCamera.localEulerAngles = new Vector3(AngleX, PlayerCamera.localEulerAngles.y, PlayerCamera.localEulerAngles.z);
    transform.Rotate(Vector3.up * MouseInputX);

    // Jumping the player
    if (Input.GetKeyDown(KeyCode.Space) && PlayerIsGrounded)
    {
      PlayerRigidBody.AddForce(Vector3.up * PlayerJumpForce, ForceMode.Impulse);
      PlayerIsGrounded = false;
    }
  }

  void OnCollisionEnter()
  {
    PlayerIsGrounded = true;
  }
}
