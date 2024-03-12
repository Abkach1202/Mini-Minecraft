using UnityEngine;

public class ChestSlots : MonoBehaviour
{
  // The number of slots in the chest
  public const int DIM_SLOTS = 6;

  // The index of the slot in the chest
  [SerializeField] private int Index;
  // The image of the slot
  [SerializeField] private UnityEngine.UI.Image Image;
  // The background image of the slot
  [SerializeField] private UnityEngine.UI.Image BackgroundImage;
  // The player's movement containing the chest inventory
  [SerializeField] private PlayerMovement PlayerMovement;

  // Update is called once per frame
  void Update()
  {
    // The chest inventory
    ChestInventory ChestInventory = PlayerMovement.GetInteractable() as ChestInventory;
    InventoryItem Item;
    // If the chest inventory and the item are not null
    if (ChestInventory != null && (Item = ChestInventory.GetItem(Index)) != null)
    {
      // Set the sprite of the item
      Image.sprite = Item.GetSprite();
      // If the index of the slot is the target
      if (Index == ChestInventory.GetTarget())
      {
        // Set the background image to yellow
        BackgroundImage.color = Color.red;
      }
      else
      {
        // Set the background image to default
        BackgroundImage.color = Color.yellow;
      }
    }
    else
    {
      // Set the sprite to default
      Image.sprite = null;
      BackgroundImage.color = Color.yellow;
      Image.color = Color.yellow;
    }
  }
}
