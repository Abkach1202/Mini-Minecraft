using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // Speed of movement
  [SerializeField] private float PlayerSpeed;
  // Mouse sensitivity
  [SerializeField] private float PlayerMouseSensitivity;
  // Speed of regeneration of the stamina
  [SerializeField] private float PlayerStaminaGeneration;

  // If the player is running
  private bool PlayerIsRunning;
  // if the player is blocked
  private bool PlayerIsBlocked;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;
  // The Interactable connected
  private IInteractable Interactable;

  public IInteractable GetInteractable()
  {
    return Interactable;
  }

  public bool IsBlocked()
  {
    return PlayerIsBlocked;
  }

  public void BlockPlayer()
  {
  PlayerIsBlocked = true;
  }

  public IEnumerator UnblockPlayer(float Duration)
  {
    yield return new WaitForSeconds(Duration);
    PlayerIsBlocked = false;
  }

  void Start()
  {
  PlayerRigidBody = GetComponent<Rigidbody>();
  PlayerIsRunning = false;
  Cursor.visible = false;
  Cursor.lockState = CursorLockMode.Locked;
  }

  void Update()
  {
  PlayerHealth Player = GetComponent<PlayerHealth>();
  // Moving faster if shift is pressed
  if (Input.GetKeyDown(KeyCode.LeftShift) && Player.GetStamina() >= PlayerHealth.MAXSTAMINA / 4 && !PlayerIsBlocked)
  {
    PlayerSpeed *= 2;
    PlayerIsRunning = true;
  }

  // Moving slower if shift is released or stamina lower than 0
  if ((Input.GetKeyUp(KeyCode.LeftShift) || Player.GetStamina() <= 0 || PlayerIsBlocked) && PlayerIsRunning)
  {
    PlayerSpeed /= 2;
    PlayerIsRunning = false;
  }

  // Regeneration of the stamina
  if (PlayerIsRunning)
  {
    Player.RemoveStamina(PlayerStaminaGeneration * Time.deltaTime);
  }
  else if (Player.GetStamina() < PlayerHealth.MAXSTAMINA)
  {
    Player.AddStamina(PlayerStaminaGeneration * Time.deltaTime);
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

  void OnTriggerStay(Collider Other)
  {
  if (Other.TryGetComponent(out IInteractable FoundItem))
  {
    FoundItem.Interact(this);
    Interactable = FoundItem;
  }
  }
}
