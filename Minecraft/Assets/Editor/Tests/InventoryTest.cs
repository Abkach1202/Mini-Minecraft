using NUnit.Framework;

public class InventoryTest
{
    // Test the IsEmpty function
    [Test]
    public void InventoryTestIsEmpty()
    {
        Inventory inventory = new Inventory();
        Assert.IsTrue(inventory.IsEmpty());

        inventory.Add(0, "Item", null, null, 1);
        Assert.IsTrue(!inventory.IsEmpty());
    }

    // Test the GetCount function
    [Test]
    public void InventoryTestGetCount()
    {
        Inventory inventory = new Inventory();
        Assert.AreEqual(0, inventory.GetCount());

        inventory.Add(0, "Item", null, null, 1);
        Assert.AreEqual(1, inventory.GetCount());
    }

    // Test the GetItem function with an invalid index
    [Test]
    public void InventoryTestGetItemInvalidIndex()
    {
        Inventory inventory = new Inventory();
        InventoryItem item = inventory.GetItem(0);
        Assert.IsNull(item);

        inventory.Add(0, "Item", null, null, 1);
        item = inventory.GetItem(1);
        Assert.IsNull(item);

        item = inventory.GetItem(-1);
        Assert.IsNull(item);
    }

    // Test to check adding an item to the inventory
    [Test]
    public void InventoryTestAdding()
    {
        Inventory inventory = new Inventory();
        inventory.Add(0, "Item", null, null, 1);

        Assert.IsTrue(!inventory.IsEmpty());
    }

    // Test to check removing an item from the inventory
    [Test]
    public void InventoryTestRemoving()
    {
        Inventory inventory = new Inventory();
        inventory.Add(0, "Item", null, null, 1);
        inventory.Remove(0, 1);

        Assert.IsTrue(inventory.IsEmpty());
    }

    // Test to check adding quantity to an item in the inventory
    [Test]
    public void InventoryTestAddingQuantity()
    {
        Inventory inventory = new Inventory();
        inventory.Add(0, "Item", null, null, 1);
        inventory.Add(0, "Item", null, null, 1);
        Assert.AreEqual(1, inventory.GetCount());

        InventoryItem item = inventory.GetItem(0);
        Assert.AreEqual(2, item.GetQuantity());
    }

    // Test to check removing quantity from an item in the inventory
    [Test]
    public void InventoryTestRemovingQuantity()
    {
        Inventory inventory = new Inventory();
        inventory.Add(0, "Item", null, null, 2);
        inventory.Remove(0, 1);
        Assert.AreEqual(1, inventory.GetCount());

        InventoryItem item = inventory.GetItem(0);
        Assert.AreEqual(1, item.GetQuantity());

        inventory.Remove(0, 3);
        Assert.IsTrue(inventory.IsEmpty());
    }
}
