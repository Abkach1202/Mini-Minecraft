using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
  // The jumping force
  [SerializeField] private float PlayerJumpForce;
  // if the player is grounded
  private bool PlayerIsGrounded;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;
  // The Player Input
  private PlayerInput PlayerInput;
  // The player InvenPlayerInventory
  private PlayerInventory PlayerInventory;

  // Start is called before the first frame update
  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
    PlayerInput = GetComponent<PlayerInput>();
    PlayerInventory = GetComponent<PlayerInventory>();
  }

  // FixedUpdate is called once per frame
  void FixedUpdate()
  {
    // Jumping the player
    if (PlayerInput.IsKeySpaceClicked() && PlayerIsGrounded && !PlayerInventory.IsChestOpened())
    {
      PlayerRigidBody.AddForce(Vector3.up * PlayerJumpForce, ForceMode.Impulse);
      PlayerIsGrounded = false;
    }
  }

  // Function to make the player grounded
  void OnCollisionEnter()
  {
    PlayerIsGrounded = true;
  }
}
