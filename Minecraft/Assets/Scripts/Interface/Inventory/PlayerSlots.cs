using TMPro;
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
  // The player's inventory to show
  [SerializeField] private PlayerInventory PlayerInventory;
  
  // The text of the slot
  private TextMeshProUGUI Text;

  // Start is called before the first frame update
  void Start()
  {
    Text = GetComponentInChildren<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
    // The chest inventory
    InventoryItem Item = PlayerInventory.GetItem(PlayerInventory.GetFirstIndex() + Index);     
    // If the chest inventory and the item are not null
    if (Item != null) 
    {
      // Set the sprite of the item
      Image.sprite = Item.GetSprite();
      // Set the text of the item
      Text.text = Item.GetQuantity().ToString();
      // If the index of the slot is the target
      if (Index == PlayerInventory.GetTarget())
      {
        // Set the background image to gray
        BackgroundImage.color = Color.red;
      }
      else
      {
        // Set the background image to default
        BackgroundImage.color = Color.gray;
      }
    }
    else
    {
      // Set the sprite to default
      Image.sprite = null;
      BackgroundImage.color = Color.gray;
      Image.color = Color.gray;
      Text.text = "";
    }
  }
}
