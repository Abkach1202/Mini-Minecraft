using UnityEngine;

public class ChestInventory : MonoBehaviour, IInteractable
{
  // The UI of the chest
  [SerializeField] private GameObject ChestUI;
  // The inventory of the Chest
  private Inventory ChestItems;
  // The item target
  private int Target;

  // Start is called before the first frame update
  void Start()
  {
    ChestItems = new Inventory();
    Target = 0;
  }

  // Function to get the inventory of the chest
  public InventoryItem GetItem(int Index)
  {
    return ChestItems.GetItem(Index);
  }

  // Function to get the item target
  public int GetTarget()
  {
    return Target;
  }

  // Function to give an item to the player
  public void GiveTargettedItem(PlayerInventory Player)
  {
    InventoryItem Item = ChestItems.GetItem(Target);
    Player.Collect(Item);
    ChestItems.Remove(Item.GetID(), 1);
  }

  // Overriding the Interact function
  public void Interact(MonoBehaviour Interactor, KeyCode Key)
  {
    PlayerInventory PlayerInventory = Interactor.GetComponent<PlayerInventory>();
    if (PlayerInventory.IsChestOpened())
    {
      if (Key == KeyCode.RightArrow && !ChestItems.IsEmpty())
      {
        Target = (Target + 1) % ChestItems.GetCount();
      }
      else if (Key == KeyCode.LeftArrow && !ChestItems.IsEmpty())
      {
        Target = (Target + 1) % ChestItems.GetCount();
      }
      else if (Key == KeyCode.DownArrow && !ChestItems.IsEmpty())
      {
        Target = (Target + ChestSlots.DIM_SLOTS) % ChestItems.GetCount();
      }
      else if (Key == KeyCode.UpArrow && !ChestItems.IsEmpty())
      {
        Target = (Target >= ChestSlots.DIM_SLOTS) ? (Target - ChestSlots.DIM_SLOTS) % ChestItems.GetCount() : 0;
      }
      else if (Key == KeyCode.G && !ChestItems.IsEmpty())
      {
        // Gives the player the item
        GiveTargettedItem(PlayerInventory);
      }
      else if (Key == KeyCode.A)
      {
        // Collects the item
        InventoryItem Item = PlayerInventory.GiveTargettedItem();
        if (Item != null)
        {
          ChestItems.Add(Item.GetID(), Item.GetName(), Item.GetPrefab(), Item.GetSprite(), 1);
        }
      }
      else if (Key == KeyCode.Mouse0)
      {
        ChestUI.SetActive(false);
        PlayerInventory.CloseChest();
      }
    }
    else if (Key == KeyCode.Mouse0)
    {
      ChestUI.SetActive(true);
      PlayerInventory.OpenChest();
    }
  }
}
