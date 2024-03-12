using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlots : MonoBehaviour
{
  // The index of the slot in the chest
  [SerializeField] private int Index;
  // The image of the slot
  [SerializeField] private UnityEngine.UI.Image Image;
  // The background image of the slot
  [SerializeField] private UnityEngine.UI.Image BackgroundImage;
  // The player's movement containing the chest inventory
  [SerializeField] private PlayerInventory PlayerInventory;

  // Update is called once per frame
  void Update()
  {
    // The chest inventory
    InventoryItem Item = PlayerInventory.GetInventory().GetItem(Index);     
    // If the chest inventory and the item are not null
    if (Item != null) 
    {
      // Set the sprite of the item
      Image.sprite = Item.GetSprite();
      // If the index of the slot is the target
      if (Index == PlayerInventory.GetItemTarget())
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
      Image.color = Color.yellow;
    }
  }
}
