using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
  private readonly List<InventoryItem> InventoryItems;

  public Inventory()
  {
    InventoryItems = new List<InventoryItem>();
  }

  public void Add(int ID, string Name, GameObject Prefab, int Quantity)
  {
    InventoryItem Item = InventoryItems.Find(x => x.GetID() == ID);
    if (Item == null)
    {
      Item = new InventoryItem(ID, Name, Prefab, Quantity);
      InventoryItems.Add(Item);
    }
    else
    {
      Item.AddQuantity(Quantity);
    }
  }

  public void Remove(int ID, int Quantity)
  {
    InventoryItem Item = InventoryItems.Find(x => x.GetID() == ID);
    if (Item != null)
    {
      Item.AddQuantity(-Quantity);
      if (Item.GetQuantity() == 0)
      {
        InventoryItems.Remove(Item);
      }
    }
  }

  public int GetCount()
  {
    return InventoryItems.Count;
  }

  public bool IsEmpty()
  {
    return GetCount() == 0;
  }

  public InventoryItem GetItem(int Index)
  {
    if (0 <= Index && Index <= GetCount() - 1)
    {
      return InventoryItems[Index];
    }
    return null;
  }

  public void Display()
  {
    Debug.Log("Inventory:");
    foreach (InventoryItem item in InventoryItems)
    {
      Debug.Log(item.GetName() + " " + item.GetQuantity());
    }
  }
}