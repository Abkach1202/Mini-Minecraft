using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  private Inventory Inventory { get; }
  public Transform Map;

  public PlayerInventory()
  {
    Inventory = new Inventory();
  }

  public void Collect(Resource Resource)
  {
    Inventory.Add(Resource.ID, Resource.NameResource, Resource.gameObject, 1);
  }

  void OnTriggerStay(Collider Other)
  {
    if (Other.TryGetComponent(out Resource foundItem) && Input.GetMouseButtonDown(0))
    {
      foundItem.Interact(this);
    }
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(1) && Inventory.Items.Count != 0)
    {
      // Creates a new object and gives it the item data
      GameObject droppedItem = Instantiate(Inventory.Items[Inventory.Items.Count-1].Model, Map);
      droppedItem.name = Inventory.Items[Inventory.Items.Count-1].Name;
      droppedItem.transform.position = transform.position;

      // Removes the item from the inventory
      Inventory.Remove(Inventory.Items[Inventory.Items.Count-1].ID, 1);
    }
  }
}