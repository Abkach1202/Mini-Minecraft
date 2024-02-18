using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // Speed of movement
  [SerializeField] private float PlayerSpeed;
  // Mouse sensitivity
  [SerializeField] private float PlayerMouseSensitivity;
  // Speed of regeneration of the stamina
  [SerializeField] private float PlayerStaminaGeneration;
  // The stamina of the player
  private float PlayerStamina;
  // If the player is running
  private bool PlayerIsRunning;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;

  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
    PlayerIsRunning = false;
    PlayerStamina = 20;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
    // Moving faster if shift is pressed
    if (Input.GetKeyDown(KeyCode.LeftShift) && PlayerStamina >= 5)
    {
      PlayerSpeed *= 2;
      PlayerIsRunning = true;
    }

    // Moving slower if shift is released or stamina lower than 0
    if ((Input.GetKeyUp(KeyCode.LeftShift) || PlayerStamina <= 0) && PlayerIsRunning)
    {
      PlayerSpeed /= 2;
      PlayerIsRunning = false;
    }

    // Regeneration of the stamina
    if (PlayerIsRunning)
    {
      PlayerStamina -= PlayerStaminaGeneration * Time.deltaTime;
    }
    else if (PlayerStamina < 20)
    {
      PlayerStamina += PlayerStaminaGeneration * Time.deltaTime;
    }
  }

  void FixedUpdate()
  {
    // Directional and mouse input
    float DirectionInputV = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
    float DirectionInputH = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
    float MouseInputX = Input.GetAxis("Mouse X") * PlayerMouseSensitivity * Time.deltaTime;

    // Calculate movement direction based on player's rotation
    Vector3 MovementDirection = transform.forward * DirectionInputV + transform.right * DirectionInputH;
    MovementDirection.y = PlayerRigidBody.velocity.y;

    // Moving the player
    if (!GetComponent<PlayerDashing>().IsDashing())
    {
      PlayerRigidBody.velocity = MovementDirection;
    }

    // Rotating the player
    transform.Rotate(Vector3.up * MouseInputX);
  }
}
