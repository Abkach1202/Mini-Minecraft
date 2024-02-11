using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    List<InventoryItem> items;

    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    public void add(int id, string name, int quantity)
    {
        InventoryItem item = items.Find(x => x.id == id);
        if (item == null)
        {
            items.Add(new InventoryItem(id, name, quantity));
        }
        else
        {
            item.quantity += quantity;
        }
    }

    public void Display()
    {
        foreach (InventoryItem item in items)
        {
        }
    }
}