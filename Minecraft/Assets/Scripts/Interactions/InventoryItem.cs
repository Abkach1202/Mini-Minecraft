using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int id { get; private set; }
    public string name { get; set; }
    public int quantity { get; set; }

    public InventoryItem(int id, string name, int quantity)
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
    }
}