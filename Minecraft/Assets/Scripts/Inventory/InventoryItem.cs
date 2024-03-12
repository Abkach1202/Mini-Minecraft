using UnityEngine;

public class InventoryItem
{
  public const int MAX_QUANTITY = 3;
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

  // Constructor
  public InventoryItem(int ID, string Name, GameObject Prefab, Sprite Image, int Quantity)
  {
    this.ItemID = ID;
    this.ItemName = Name;
    this.ItemPrefab = Prefab;
    this.ItemSprite = Image;
    this.ItemQuantity = (Quantity >= 1) ? Quantity : 1;
  }

  // Function to get the item's ID
  public int GetID()
  {
    return ItemID;
  }

  // Function to get the item's name
  public string GetName()
  {
    return ItemName;
  }

  // Function to get the item's prefab
  public GameObject GetPrefab()
  {
    return ItemPrefab;
  }

  // Function to get the item's sprite
  public Sprite GetSprite()
  {
    return ItemSprite;
  }

  // Function to get the item's quantity
  public int GetQuantity()
  {
    return ItemQuantity;
  }

  // Function to add quantity to the item
  public void AddQuantity(int Quantity)
  {
    ItemQuantity += Quantity;
    ItemQuantity = (ItemQuantity > 0) ? ItemQuantity : 0;
  }
}