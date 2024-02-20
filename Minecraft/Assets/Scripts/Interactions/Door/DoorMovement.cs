using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // The pivot and the door
    [SerializeField] private GameObject Pivot, Door;
    // Maximum Angle of rotation
    [SerializeField] private int Angle;
    // The current angle of the rotation
    private int CurrentAngle;
    // If the player is detected
    private bool PlayerDetected;

    void Start()
    {
        this.CurrentAngle = 0;
        this.PlayerDetected = false;
    }

    void Update()
    {
        if (PlayerDetected && CurrentAngle < Angle)
        {
            CurrentAngle += 1;
            Door.transform.RotateAround(Pivot.transform.position, Vector3.up, CurrentAngle * Time.deltaTime);
        }
        else if (!PlayerDetected && CurrentAngle > 0)
        {
            CurrentAngle -= 1;
            Door.transform.RotateAround(Pivot.transform.position, -Vector3.up, CurrentAngle * Time.deltaTime);
        }
        
        if (CurrentAngle == 0)
        {
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
