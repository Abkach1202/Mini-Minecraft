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

    public bool IsDashing() {
        return PlayerIsDashing;
    }

    private void ResetDash() {
        PlayerIsDashing = false;
    }

    private bool IsDashValid() {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerRigidBody.AddForce(DashingDirection, ForceMode.Impulse);
            PlayerIsDashing = true;
            Invoke(nameof(ResetDash), PlayerDashDuration);
        }
    }
}
