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
  // The UI of the chest
  [SerializeField] private GameObject ChestUI;

  // If the player is running
  private bool PlayerIsRunning;
  // if the player is blocked
  private bool PlayerIsBlocked;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;
  // The player input
  private PlayerInput PlayerInput;
  // The player health
  private PlayerHealth PlayerHealth;
  // The player inventory
  private PlayerInventory PlayerInventory;
  // The Interactable connected
  private IInteractable Interactable;

  // Start is called before the first frame update
  void Start()
  {
    PlayerHealth = GetComponent<PlayerHealth>();
    PlayerInput = GetComponent<PlayerInput>();
    PlayerInventory = GetComponent<PlayerInventory>();
    PlayerRigidBody = GetComponent<Rigidbody>();
    PlayerIsRunning = false;
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
  }

  // Function to check if the player is blocked
  public bool IsBlocked()
  {
    return PlayerIsBlocked;
  }

  // Function to block the player
  public void BlockPlayer()
  {
    PlayerIsBlocked = true;
  }

  // Function to unblock the player
  public IEnumerator UnblockPlayer(float Duration)
  {
    yield return new WaitForSeconds(Duration);
    PlayerIsBlocked = false;
  }

  // Function to run
  public void Run()
  {
    if (PlayerHealth.GetStamina() >= PlayerHealth.MAXSTAMINA / 4 && !PlayerIsBlocked && !PlayerIsRunning)
    {
      PlayerSpeed *= 2;
      PlayerIsRunning = true;
    }
  }

  // Function to stop running
  public void StopRun()
  {
    if (PlayerIsRunning)
    {
      PlayerSpeed /= 2;
      PlayerIsRunning = false;
    }
  }

  // Function to get the interactable
  public IInteractable GetInteractable()
  {
    return Interactable;
  }

  // Function to annulate the interactable
  public void AnnulateInteractable()
  {
    Interactable = null;
  }

  // Update is called once per frame
  void Update()
  {
    // Regeneration of the stamina
    if (PlayerIsRunning)
    {
      PlayerHealth.RemoveStamina(PlayerStaminaGeneration * Time.deltaTime);
    }
    else if (PlayerHealth.GetStamina() < PlayerHealth.MAXSTAMINA)
    {
      PlayerHealth.AddStamina(PlayerStaminaGeneration * Time.deltaTime);
    }
  }

  // FixedUpdate is called once per frame
  void FixedUpdate()
  {
    if (!PlayerInventory.IsChestOpened())
    {
      // Directional input
      float DirectionInputV = PlayerInput.GetAxisV() * PlayerSpeed * Time.deltaTime;
      float DirectionInputH = PlayerInput.GetAxisH() * PlayerSpeed * Time.deltaTime;
      // Calculate movement direction based on player's rotation
      Vector3 MovementDirection = transform.forward * DirectionInputV + transform.right * DirectionInputH;
      MovementDirection.y = PlayerRigidBody.velocity.y;
      // Moving the player
      if (!GetComponent<PlayerDashing>().IsDashing())
      {
        PlayerRigidBody.velocity = MovementDirection;
      }
    }
    // Rotating the player
    float MouseInputX = PlayerInput.GetMouseX() * PlayerMouseSensitivity * Time.deltaTime;
    transform.Rotate(Vector3.up * MouseInputX);
  }

  // Function to interact with the environment
  void OnTriggerStay(Collider Other)
  {
    if (Other.TryGetComponent(out IInteractable FoundItem))
    {
      Interactable = FoundItem;
      if (FoundItem is LifeTrap || FoundItem is StaminaTrap)
      {
        FoundItem.Interact(this, KeyCode.None);
      }
      if (FoundItem is ChestInventory)
      {
        ChestUI.SetActive(true);
      }
    }
  }

  // Function to stop interacting with the environment
  void OnTriggerExit(Collider Other)
  {
    AnnulateInteractable();
    ChestUI.SetActive(false);
  }
}
