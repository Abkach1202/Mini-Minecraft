using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public int ID { get; private set; }
    public string Name;
    public int Quantity;
    public GameObject Model;

    public InventoryItem(int ID, string Name, GameObject Model, int Quantity)
    {
        this.ID = ID;
        this.Name = Name;
        this.Quantity = Quantity;
        this.Model = Model;
    }
}