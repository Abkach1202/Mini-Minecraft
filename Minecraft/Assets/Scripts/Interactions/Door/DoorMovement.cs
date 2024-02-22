using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // The pivot and the door
    [SerializeField] private GameObject Pivot, Door;
    // Maximum Angle of rotation
    [SerializeField] private int Angle;
    // Speed of rotation
    [SerializeField] private float RotationSpeed;
    // The current angle of the rotation
    private float CurrentAngle;
    // If the player is detected
    private bool PlayerDetected;

    void Start()
    {
        this.CurrentAngle = 0f;
        this.PlayerDetected = false;
    }

    void Update()
    {
        if (PlayerDetected && CurrentAngle < Angle)
        {
            CurrentAngle += RotationSpeed * Time.deltaTime;
            Door.transform.RotateAround(Pivot.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
        }
        else if (!PlayerDetected && CurrentAngle > 0f)
        {
            CurrentAngle -= RotationSpeed * Time.deltaTime;
            Door.transform.RotateAround(Pivot.transform.position, -Vector3.up, RotationSpeed * Time.deltaTime);
        }
        
        if (CurrentAngle <= 0f)
        {
            CurrentAngle = 0f;
            Door.transform.rotation = Quaternion.Euler(0, 180, 0);
            Door.transform.localPosition = Vector3.zero;
        }
    }
    void OnTriggerEnter()
    {
        PlayerDetected = true;
    }

    void OnTriggerExit()
    {
        PlayerDetected = false;
    }
}
