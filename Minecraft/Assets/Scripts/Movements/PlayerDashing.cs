using UnityEngine;

public class PlayerDashing : MonoBehaviour
{
  // The dash force
  [SerializeField] private float PlayerDashForce;
  // The Dash Duration
  [SerializeField] private float PlayerDashDuration;
  // if the player is dashing
  private bool PlayerIsDashing;
  // The rigidBody associated
  private Rigidbody PlayerRigidBody;
  // The Player Input
  private PlayerInput PlayerInput;
  // The player inventory
  private PlayerInventory PlayerInventory;
  // The collider associated
  private CapsuleCollider PlayerCollider;

  // Start is called before the first frame update
  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
    PlayerCollider = GetComponentInChildren<CapsuleCollider>();
    PlayerInput = GetComponent<PlayerInput>();
    PlayerInventory = GetComponent<PlayerInventory>();
    PlayerIsDashing = false;
  }

  // Function to check if the player is dashing
  public bool IsDashing()
  {
    return PlayerIsDashing;
  }

  // Function to reset the dash
  private void ResetDash()
  {
    PlayerCollider.enabled = true;
    PlayerRigidBody.useGravity = true;
    PlayerIsDashing = false;
  }

  // Function to get the final position of the dash
  private Vector3 GetFinalPosition()
  {
    Vector3 initialVelocity, endPosition;
    // Calculate the initial velocity
    initialVelocity = transform.forward.normalized * PlayerDashForce / PlayerRigidBody.mass;
    // Calculate the time it will take to stop
    float timeToStop = initialVelocity.magnitude / PlayerRigidBody.drag; // Supposant que la traînée est la seule force de résistance
    // Calculates the final position of the dash
    endPosition = transform.position + initialVelocity * timeToStop - timeToStop * timeToStop * Physics.gravity / 2f;
    return endPosition;
  }

  // Function to check if the dash is valid
  private bool IsDashValid()
  {
    if (PlayerIsDashing)
    {
      return false;
    }
    // Calculate the final position of the dash
    Vector3 endPosition = GetFinalPosition();
    Vector3 endCenter = endPosition + PlayerCollider.center;
    Vector3 point1 = endCenter + transform.up * PlayerCollider.height / 2f;
    Vector3 point2 = endCenter - transform.up * PlayerCollider.height / 2f;

    // Check if the player is not colliding with anything
    Collider[] colliders = Physics.OverlapCapsule(point1, point2, PlayerCollider.radius);
    foreach (Collider collider in colliders)
    {
      if (collider.gameObject != gameObject)
      {
        return false;
      }
    }
    return true;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (!PlayerInventory.IsChestOpened())
    {
      // Directional input
      float DirectionInputV = PlayerInput.GetAxisV() * PlayerDashForce;
      float DirectionInputH = PlayerInput.GetAxisH() * PlayerDashForce;

      // Calculate movement direction based on player's rotation
      Vector3 DashingDirection = transform.forward * DirectionInputV + transform.right * DirectionInputH;

      // Dashing the player
      if (PlayerInput.IsKeyBClicked() && IsDashValid())
      {
        PlayerRigidBody.AddForce(DashingDirection, ForceMode.Impulse);
        PlayerRigidBody.useGravity = false;
        PlayerIsDashing = true;
        PlayerCollider.enabled = false;
        Invoke(nameof(ResetDash), PlayerDashDuration);
      }
    }
  }
}
