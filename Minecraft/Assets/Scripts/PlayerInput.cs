using UnityEngine;

public class PlayerInput : MonoBehaviour
{
  // The player movement
  private PlayerMovement PlayerMovement;
  // The player inventory
  private PlayerInventory PlayerInventory;
  // The player Health
  private PlayerHealth PlayerHealth;
  // If the key B is clicked
  private bool KeyBIsClicked;
  // If the key Space is clicked
  private bool KeySpaceIsClicked;
  // The direction input for the player
  private float DirectionInputV;
  // The direction input for the player
  private float DirectionInputH;
  // The mouse input for the player
  private float MouseInputX;
  // The mouse input for the player
  private float MouseInputY;

  // Start is called before the first frame update
  void Start()
  {
    PlayerMovement = GetComponent<PlayerMovement>();
    PlayerInventory = GetComponent<PlayerInventory>();
    PlayerHealth = GetComponent<PlayerHealth>();
  }

  // Function to check if the key B is clicked
  public bool IsKeyBClicked()
  {
    return KeyBIsClicked;
  }

  // Function to check if the key Space is clicked
  public bool IsKeySpaceClicked()
  {
    return KeySpaceIsClicked;
  }

  // Function to get the input for the horizontal axis
  public float GetAxisH()
  {
    return DirectionInputH;
  }

  // Function to get the input for the vertical axis
  public float GetAxisV()
  {
    return DirectionInputV;
  }

  // Function to get the input for the mouse X
  public float GetMouseX()
  {
    return MouseInputX;
  }

  // Function to get the input for the mouse Y
  public float GetMouseY()
  {
    return MouseInputY;
  }

  // Update is called once per frame
  void Update()
  {
    IInteractable Interactable = PlayerMovement.GetInteractable();
    // Input for the interactable
    if (Interactable != null)
    {
      if (Input.GetKeyUp(KeyCode.UpArrow))
      {
        Interactable.Interact(this, KeyCode.UpArrow);
      }
      if (Input.GetKeyUp(KeyCode.DownArrow))
      {
        Interactable.Interact(this, KeyCode.DownArrow);
      }
      if (Input.GetKeyUp(KeyCode.LeftArrow))
      {
        Interactable.Interact(this, KeyCode.LeftArrow);
      }
      if (Input.GetKeyUp(KeyCode.RightArrow))
      {
        Interactable.Interact(this, KeyCode.RightArrow);
      }
      if (Input.GetKeyUp(KeyCode.G))
      {
        Interactable.Interact(this, KeyCode.G);
      }
      if (Input.GetKeyUp(KeyCode.A))
      {
        Interactable.Interact(this, KeyCode.A);
      }
      if (Input.GetKeyUp(KeyCode.U))
      {
        Interactable.Interact(this, KeyCode.U);
      }
      if (Input.GetKeyUp(KeyCode.L))
      {
        Interactable.Interact(this, KeyCode.L);
      }
      if (Input.GetMouseButtonDown(0))
      {
        Interactable.Interact(this, KeyCode.Mouse0);
      }
    }

    // Input for the player
    if (Input.GetMouseButtonDown(1))
    {
      PlayerInventory.DropTargettedItem();
    }
    if (Input.GetKeyUp(KeyCode.K))
    {
      PlayerInventory.NextItem();
    }
    if (Input.GetKeyUp(KeyCode.J))
    {
      PlayerInventory.PreviousItem();
    }
    if (Input.GetKeyUp(KeyCode.J))
    {
      PlayerInventory.PreviousItem();
    }
    if (Input.GetKeyDown(KeyCode.LeftShift))
    {
      PlayerMovement.Run();
    }
    if (Input.GetKeyUp(KeyCode.LeftShift) || PlayerHealth.GetStamina() <= 0 || PlayerMovement.IsBlocked())
    {
      PlayerMovement.StopRun();
    }
    if (Input.GetKeyUp(KeyCode.B))
    {
      KeyBIsClicked = true;
    }
    else
    {
      KeyBIsClicked = false;
    }
    if (Input.GetKeyUp(KeyCode.Space))
    {
      KeySpaceIsClicked = true;
    }
    else
    {
      KeySpaceIsClicked = false;
    }

    // Input for movement
    DirectionInputV = Input.GetAxis("Vertical");
    DirectionInputH = Input.GetAxis("Horizontal");
    MouseInputX = Input.GetAxis("Mouse X");
    MouseInputY = Input.GetAxis("Mouse Y");
  }
}
