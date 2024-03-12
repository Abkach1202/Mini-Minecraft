using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  // The inventory of the player
  private Inventory PlayerItems;
  // The item target
  private int Target;
  // The first index of the slot to show
  private int FirstIndex;

  // If the chest inventory is open
  private bool ChestOpened;

  // Start is called before the first frame update
  void Start()
  {
    PlayerItems = new Inventory();
    Target = 0;
    FirstIndex = 0;
    ChestOpened = false;
  }

  // Function to check if the UI Chest Inventory is open
  public bool IsChestOpened()
  {
    return ChestOpened;
  }

  // Function to open the UI Chest Inventory
  public void OpenChest()
  {
    ChestOpened = true;
  }

  // Function to close the UI Chest Inventory
  public void CloseChest()
  {
    ChestOpened = false;
  }

  // Function to Collect a resource
  public void Collect(Resource Resource)
  {
    PlayerItems.Add(Resource.GetID(), Resource.GetNameResource(), Resource.GetPrefab(), Resource.GetSprite(), 1);
  }

  // Function to Collect an inventory item
  public void Collect(InventoryItem Item)
  {
    PlayerItems.Add(Item.GetID(), Item.GetName(), Item.GetPrefab(), Item.GetSprite(), 1);
  }

  // Function to get the inventory of the chest
  public InventoryItem GetItem(int Index)
  {
    return PlayerItems.GetItem(Index);
  }

  // Function to get the first index of the slot to show
  public int GetFirstIndex()
  {
    return FirstIndex;
  }

  public void UpdateFirstIndex()
  {
    if (Target <= FirstIndex)
    {
      FirstIndex = Target;
    }
    else if (Target >= FirstIndex + ChestSlots.SLOTS_ROW)
    {
      FirstIndex += 1;
    }
  }

  // Function to get the item target
  public int GetTarget()
  {
    return Target;
  }

  // Function to increment the item target
  public void NextItem()
  {
    if (!PlayerItems.IsEmpty())
    {
      Target = (Target + 1) % PlayerItems.GetCount();
      UpdateFirstIndex();
    }
  }

  // Function to decrement the item target
  public void PreviousItem()
  {
    if (!PlayerItems.IsEmpty())
    {
      Target = (Target - 1) % PlayerItems.GetCount();
      if (Target < 0) Target += PlayerItems.GetCount();
      UpdateFirstIndex();
    }
  }

  // Function to get the current InventoryItem of the player
  public InventoryItem GiveTargettedItem()
  {
    InventoryItem Item = null;
    if (!PlayerItems.IsEmpty())
    {
      Item = PlayerItems.GetItem(Target);
      PlayerItems.Remove(Target, 1);
      Target = (!PlayerItems.IsEmpty()) ? Target % PlayerItems.GetCount() : 0;
    }
    return Item;
  }

  // Function to drop the current item
  public void DropTargettedItem()
  {
    if (!PlayerItems.IsEmpty())
    {
      // Creates a new object 
      InventoryItem Item = PlayerItems.GetItem(Target);
      GameObject DroppedItem = Instantiate(Item.GetPrefab(), transform.parent);
      // Gives it the item data
      DroppedItem.name = Item.GetName();
      DroppedItem.transform.position = transform.position + transform.forward;
      DroppedItem.SetActive(true);

      // Removes the item from the inventory
      PlayerItems.Remove(Target, 1);
      Target = (!PlayerItems.IsEmpty()) ? Target % PlayerItems.GetCount() : 0;
    }
  }
}