using UnityEngine;

public class ChestInventory : MonoBehaviour, IInteractable
{
  // The inventory of the Chest
  private Inventory ChestItems;
  // The item target
  private int ItemTarget = 0;

  void Start()
  {
    ChestItems = new Inventory();
  }

  public Inventory GetInventory()
  {
    return ChestItems;
  }

  public int GetItemTarget()
  {
    return ItemTarget;
  }

  public void Collect(Resource Resource)
  {
    ChestItems.Add(Resource.GetID(), Resource.GetNameResource(), Resource.GetPrefab(), Resource.GetSprite(), 1);
  }

  public void Collect(InventoryItem Item)
  {
    ChestItems.Add(Item.GetID(), Item.GetName(), Item.GetPrefab(), Item.GetSprite(), 1);
  }

  public void GiveItem(PlayerInventory Player, int ID, int Quantity)
  {
    InventoryItem Item = ChestItems.GetItem(ID);
    Player.Collect(Item);
    ChestItems.Remove(Item.GetID(), Quantity);
  }

  public void Interact(MonoBehaviour Interactor)
  {
    PlayerInventory PlayerInventory = Interactor.GetComponent<PlayerInventory>();
    if (Input.GetKeyDown(KeyCode.F) && !ChestItems.IsEmpty())
    {
      ItemTarget = (ItemTarget + 1) % ChestItems.GetCount();
    }

    if (Input.GetMouseButtonDown(0) && !ChestItems.IsEmpty())
    {
      // Gets the item 
      PlayerInventory = Interactor.GetComponent<PlayerInventory>();
      // Gives the player the item
      GiveItem(PlayerInventory, ItemTarget, 1);
    }

    if (Input.GetKeyDown(KeyCode.E))
    {
      // Collects the item
      InventoryItem Item = PlayerInventory.GetCurrentItem();
      if (Item != null)
      {
        Collect(Item);
      }
    }
  }
}
