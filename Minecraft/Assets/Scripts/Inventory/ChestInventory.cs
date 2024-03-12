using UnityEngine;

public class ChestInventory : MonoBehaviour, IInteractable
{
  // The UI of the chest
  [SerializeField] private GameObject ChestUI;
  // The inventory of the Chest
  private Inventory ChestItems;
  // The item target
  private int Target;
  // The first index of the slot to show
  private int FirstIndex;


  // Start is called before the first frame update
  void Start()
  {
    ChestItems = new Inventory();
    Target = 0;
    FirstIndex = 0;
  }

  // Function to get the inventory of the chest
  public InventoryItem GetItem(int Index)
  {
    return ChestItems.GetItem(Index);
  }

  // Function to get the first index of the slot to show
  public int GetFirstIndex()
  {
    return FirstIndex;
  }

  public void UpdateFirstIndex()
  {
    if (Target < FirstIndex)
    {
      FirstIndex = Target;
    }
    else if (Target >= FirstIndex + ChestSlots.SLOTS_ROW * ChestSlots.SLOTS_COLUMN)
    {
      FirstIndex += 1;
    }
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
    ChestItems.Remove(Target, 1);
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
        UpdateFirstIndex();
      }
      else if (Key == KeyCode.LeftArrow && !ChestItems.IsEmpty())
      {
        Target = (Target + 1) % ChestItems.GetCount();
        UpdateFirstIndex();
      }
      else if (Key == KeyCode.DownArrow && !ChestItems.IsEmpty())
      {
        Target = (Target + ChestSlots.SLOTS_ROW) % ChestItems.GetCount();
        UpdateFirstIndex();
      }
      else if (Key == KeyCode.UpArrow && !ChestItems.IsEmpty())
      {
        Target = (Target >= ChestSlots.SLOTS_ROW) ? (Target - ChestSlots.SLOTS_ROW) % ChestItems.GetCount() : 0;
        UpdateFirstIndex();
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
