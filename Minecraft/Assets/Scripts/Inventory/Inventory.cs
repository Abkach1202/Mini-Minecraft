using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
  // The list of items in the inventory
  private readonly List<InventoryItem> InventoryItems;

  // Constructor
  public Inventory()
  {
    InventoryItems = new List<InventoryItem>();
  }

  // Function to add an item to the inventory
  public void Add(int ID, string Name, GameObject Prefab, Sprite Image, int Quantity)
  {
    InventoryItem Item = InventoryItems.Find(x => x.GetID() == ID && x.GetQuantity() < InventoryItem.MAX_QUANTITY);
    if (Item == null)
    {
      Item = new InventoryItem(ID, Name, Prefab, Image, Quantity);
      InventoryItems.Add(Item);
    }
    else
    {
      Item.AddQuantity(Quantity);
    }
  }

  // Function to remove an item from the inventory
  public void Remove(int Index, int Quantity)
  {
    if (0 <= Index && Index <= GetCount() - 1)
    {
      InventoryItems[Index].AddQuantity(-Quantity);
      if (InventoryItems[Index].GetQuantity() == 0)
      {
        InventoryItems.Remove(InventoryItems[Index]);
      }
    }
  }

  // Function to get the count of items in the inventory
  public int GetCount()
  {
    return InventoryItems.Count;
  }

  // Function to check if the inventory is empty
  public bool IsEmpty()
  {
    return GetCount() == 0;
  }

  // Function to get an item from the inventory
  public InventoryItem GetItem(int Index)
  {
    if (0 <= Index && Index <= GetCount() - 1)
    {
      return InventoryItems[Index];
    }
    return null;
  }
}