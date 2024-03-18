using NUnit.Framework;

public class PlayerInventoryTest
{
    // Test the PlayerInventory collect function
    [Test]
    public void PlayerInventoryTestCollect()
    {
        PlayerInventory playerInventory = new();
        InventoryItem item = new(0, "Item", null, null, 1);
        playerInventory.Collect(item);

        Assert.AreEqual(item.GetID(), playerInventory.GetItem(0).GetID());
    }

    // Test the PlayerInventory moving the target to the next item and the previous item
    [Test]
    public void PlayerInventoryTestNextItem()
    {
        PlayerInventory playerInventory = new();
        playerInventory.Collect(new InventoryItem(0, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(1, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(2, "Item", null, null, 1));

        playerInventory.NextItem();
        Assert.AreEqual(1, playerInventory.GetTarget());

        playerInventory.NextItem();
        Assert.AreEqual(2, playerInventory.GetTarget());

        playerInventory.NextItem();
        Assert.AreEqual(0, playerInventory.GetTarget());

        playerInventory.PreviousItem();
        Assert.AreEqual(2, playerInventory.GetTarget());
    }

    // Test the PlayerInventory give targetted item function
    [Test]
    public void PlayerInventoryTestGiveTargettedItem()
    {
        PlayerInventory playerInventory = new();
        playerInventory.Collect(new InventoryItem(0, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(1, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(2, "Item", null, null, 1));

        playerInventory.NextItem();
        playerInventory.NextItem();
        InventoryItem item = playerInventory.GiveTargettedItem();
        Assert.AreEqual(2, item.GetID());
        Assert.AreEqual(0, playerInventory.GetTarget());
    }

    // Test the PlayerInventory update first index function after 6 slots
    [Test]
    public void PlayerInventoryTestUpdateFirstIndex()
    {
        PlayerInventory playerInventory = new();
        playerInventory.Collect(new InventoryItem(0, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(1, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(2, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(3, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(4, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(5, "Item", null, null, 1));
        playerInventory.Collect(new InventoryItem(6, "Item", null, null, 1));

        playerInventory.NextItem();
        playerInventory.NextItem();
        playerInventory.NextItem();
        playerInventory.NextItem();
        playerInventory.NextItem();
        playerInventory.NextItem();

        playerInventory.UpdateFirstIndex();
        Assert.AreEqual(1, playerInventory.GetFirstIndex());
    }

    // Test the PlayerInventory OpenChest function
    [Test]
    public void PlayerInventoryTestOpenChest()
    {
        PlayerInventory playerInventory = new();
        Assert.IsFalse(playerInventory.IsChestOpened());
        playerInventory.OpenChest();
        Assert.IsTrue(playerInventory.IsChestOpened());
        playerInventory.CloseChest();
        Assert.IsFalse(playerInventory.IsChestOpened());
    }
}
