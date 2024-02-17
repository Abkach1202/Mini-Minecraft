using UnityEngine;

public class InventoryItem
{
  // The Item's ID
  private readonly int ItemID;
  // The Item's name
  private readonly string ItemName;
  // The Item's quantity
  private int ItemQuantity;
  // The Item's Prefab filter
  private readonly GameObject ItemPrefab;

  public InventoryItem(int ID, string Name, GameObject Prefab, int Quantity)
  {
    this.ItemID = ID;
    this.ItemName = Name;
    this.ItemQuantity = (Quantity >= 1) ? Quantity : 1;
    this.ItemPrefab = Prefab;
  }

  public int GetID()
  {
    return ItemID;
  }

  public string GetName()
  {
    return ItemName;
  }

  public int GetQuantity()
  {
    return ItemQuantity;
  }

  public GameObject GetPrefab()
  {
    return ItemPrefab;
  }

  public void AddQuantity(int Quantity)
  {
    ItemQuantity -= Quantity;
    ItemQuantity = (ItemQuantity > 0) ? ItemQuantity : 0;
  }
}