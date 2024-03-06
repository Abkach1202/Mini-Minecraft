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
  // The collider associated
  private CapsuleCollider PlayerCollider;

  public bool IsDashing()
  {
    return PlayerIsDashing;
  }

  private void ResetDash()
  {
    PlayerCollider.enabled = true;
    PlayerRigidBody.useGravity = true;
    PlayerIsDashing = false;
  }

  private Vector3 GetFinalPosition()
  {
    Vector3 initialVelocity, endPosition;
    // Calcule la vitesse initiale (velocity) que l'impulsion donnera
    initialVelocity = transform.forward.normalized * PlayerDashForce / PlayerRigidBody.mass;
    // Calcule la distance que l'objet parcourra avec cette vitesse constante
    float timeToStop = initialVelocity.magnitude / PlayerRigidBody.drag; // Supposant que la traînée est la seule force de résistance
    // Calcule la position finale
    endPosition = transform.position + initialVelocity * timeToStop - timeToStop * timeToStop * Physics.gravity / 2f;
    return endPosition;
  }

  private bool IsDashValid()
  {
    if (PlayerIsDashing)
    {
      return false;
    }
    // Calcule la position finale et les points de la capsule
    Vector3 endPosition = GetFinalPosition();
    Vector3 endCenter = endPosition + PlayerCollider.center;
    Vector3 point1 = endCenter + transform.up * PlayerCollider.height / 2f;
    Vector3 point2 = endCenter - transform.up * PlayerCollider.height / 2f;

    // Vérifie si la capsule est en collision avec un autre objet
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

  // Start is called before the first frame update
  void Start()
  {
    PlayerRigidBody = GetComponent<Rigidbody>();
    PlayerCollider = GetComponentInChildren<CapsuleCollider>();
    PlayerIsDashing = false;
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    // Directional input
    float DirectionInputV = Input.GetAxis("Vertical") * PlayerDashForce;
    float DirectionInputH = Input.GetAxis("Horizontal") * PlayerDashForce;

    // Calculate movement direction based on player's rotation
    Vector3 DashingDirection = transform.forward * DirectionInputV + transform.right * DirectionInputH;

    // Dashing the player
    if (Input.GetKeyDown(KeyCode.B) && IsDashValid())
    {
      PlayerRigidBody.AddForce(DashingDirection, ForceMode.Impulse);
      PlayerRigidBody.useGravity = false;
      PlayerIsDashing = true;
      PlayerCollider.enabled = false;
      Invoke(nameof(ResetDash), PlayerDashDuration);
    }
  }
}
