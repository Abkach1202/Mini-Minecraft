using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  // The inventory of the player
  private Inventory PlayerItems;
  // The item target
  private int ItemTarget = 0;

  public void Collect(Resource Resource)
  {
    PlayerItems.Add(Resource.GetID(), Resource.GetNameResource(), Resource.GetPrefab(), 1);
  }

  public void Collect(InventoryItem Item)
  {
    PlayerItems.Add(Item.GetID(), Item.GetName(), Item.GetPrefab(), 1);
  }

  public InventoryItem GetCurrentItem()
  {
    InventoryItem Item = null;
    if (!PlayerItems.IsEmpty())
    {
      Item = PlayerItems.GetItem(ItemTarget);
      PlayerItems.Remove(Item.GetID(), 1);
    }
    return Item;
  }

  void Start()
  {
    PlayerItems = new Inventory();
  }

  void Update()
  {
    // Changing the targetted item if shift is pressed
    if (Input.GetKeyDown(KeyCode.F) && !PlayerItems.IsEmpty())
    {
      ItemTarget = (ItemTarget + 1) % PlayerItems.GetCount();
    }

    if (Input.GetMouseButtonDown(1) && !PlayerItems.IsEmpty())
    {
      // Creates a new object 
      InventoryItem Item = PlayerItems.GetItem(ItemTarget);
      GameObject DroppedItem = Instantiate(Item.GetPrefab(), transform.parent);
      // Gives it the item data
      DroppedItem.name = Item.GetName();
      DroppedItem.transform.position = transform.position + transform.forward;
      DroppedItem.SetActive(true);

      // Removes the item from the inventory
      PlayerItems.Remove(Item.GetID(), 1);
      ItemTarget = (!PlayerItems.IsEmpty()) ? ItemTarget % PlayerItems.GetCount() : 0;
    }
  }
}