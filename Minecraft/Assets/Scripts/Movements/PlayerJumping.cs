using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
  // The jumping force
  [SerializeField] private float PlayerJumpForce;
  // if the player is grounded
  private bool PlayerIsGrounded;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;

  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
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
