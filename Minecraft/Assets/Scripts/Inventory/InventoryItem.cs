using UnityEngine;

public class InventoryItem
{
  // The Item's ID
  private readonly int ItemID;
  // The Item's name
  private readonly string ItemName;
  // The Item's Prefab filter
  private readonly GameObject ItemPrefab;
  // The Item's Sprite
  private readonly Sprite ItemSprite;
  // The Item's quantity
  private int ItemQuantity;
  
  public InventoryItem(int ID, string Name, GameObject Prefab, Sprite Image, int Quantity)
  {
  this.ItemID = ID;
  this.ItemName = Name;
  this.ItemPrefab = Prefab;
  this.ItemSprite = Image;
  this.ItemQuantity = (Quantity >= 1) ? Quantity : 1;
  }

  public int GetID()
  {
  return ItemID;
  }

  public string GetName()
  {
  return ItemName;
  }

  public GameObject GetPrefab()
  {
  return ItemPrefab;
  }

  public Sprite GetSprite()
  {
  return ItemSprite;
  }

  public int GetQuantity()
  {
  return ItemQuantity;
  }

  public void AddQuantity(int Quantity)
  {
  ItemQuantity += Quantity;
  ItemQuantity = (ItemQuantity > 0) ? ItemQuantity : 0;
  }
}