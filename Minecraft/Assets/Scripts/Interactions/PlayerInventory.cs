using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  // The inventory of the player
  private Inventory PlayerItems;
  // The item target
  private int ItemTarget = 0;

  // The Map of the game
  [SerializeField] private Transform PlayerMap;

  public void Collect(Resource Resource)
  {
    PlayerItems.Add(Resource.GetID(), Resource.GetNameResource(), Resource.GetPrefab(), 1);
  }

  void Start()
  {
    PlayerItems = new Inventory();
  }

  void OnTriggerStay(Collider Other)
  {
    if (Other.TryGetComponent(out Resource FoundItem) && Input.GetMouseButtonDown(0))
    {
      FoundItem.Interact(this);
    }
  }

  void Update()
  {
    // Changinf the targetted item if shift is pressed
    if (Input.GetKeyDown(KeyCode.C) && !PlayerItems.IsEmpty())
    {
      ItemTarget = (ItemTarget + 1) % PlayerItems.GetCount();
    }

    if (Input.GetMouseButtonDown(1) && !PlayerItems.IsEmpty())
    {
      // Creates a new object and gives it the item data
      InventoryItem Item = PlayerItems.GetItem(ItemTarget);
      Debug.Log(Item);
      Debug.Log(Item.GetPrefab());
      GameObject DroppedItem = Instantiate(Item.GetPrefab(), PlayerMap);
      DroppedItem.name = Item.GetName();
      DroppedItem.transform.position = transform.position + transform.forward;
      DroppedItem.SetActive(true);

      // Removes the item from the inventory
      PlayerItems.Remove(Item.GetID(), 1);
    }
  }
}