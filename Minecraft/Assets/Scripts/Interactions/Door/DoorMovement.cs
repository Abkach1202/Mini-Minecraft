using UnityEngine;

public class DoorMovement : MonoBehaviour, IInteractable
{
  // The pivot and the door
  [SerializeField] private GameObject Pivot, Door;
  // Maximum Angle of rotation
  [SerializeField] private int Angle;
  // Speed of rotation
  [SerializeField] private float RotationSpeed;
  // The current angle of the rotation
  private float CurrentAngle;
  // the state of the door
  private State DoorState;

  public void Interact(MonoBehaviour Interactor)
  {
    if (Input.GetKeyDown(KeyCode.U) && DoorState == State.ClosedLocked)
    {
      Door.transform.Find("Lock").gameObject.SetActive(false);
      DoorState = State.ClosedUnlocked;
    }
    else if (Input.GetKeyDown(KeyCode.L) && DoorState == State.ClosedUnlocked)
    {
      Door.transform.Find("Lock").gameObject.SetActive(true);
      DoorState = State.ClosedLocked;
    }
    if (Input.GetMouseButtonDown(0))
    {
      if (DoorState == State.ClosedUnlocked) DoorState = State.IsOpening;
      else if (DoorState == State.Opened) DoorState = State.IsClosing;
    }
  }

  void Start()
  {
    this.CurrentAngle = 0f;
    this.DoorState = State.ClosedUnlocked;
    Door.transform.Find("Lock").gameObject.SetActive(false);
  }

  void Update()
  {
    if (DoorState == State.IsOpening)
    {
      CurrentAngle += RotationSpeed * Time.deltaTime;
      Door.transform.RotateAround(Pivot.transform.position, Vector3.up, RotationSpeed * Time.deltaTime);
      if (CurrentAngle >= Angle) DoorState = State.Opened;
    }
    else if (DoorState == State.IsClosing)
    {
      CurrentAngle -= RotationSpeed * Time.deltaTime;
      Door.transform.RotateAround(Pivot.transform.position, -Vector3.up, RotationSpeed * Time.deltaTime);
      if (CurrentAngle <= 0f)
      {
        DoorState = State.ClosedUnlocked;
        CurrentAngle = 0f;
        Door.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(0, 0, 0));
      }
    }
  }

}
