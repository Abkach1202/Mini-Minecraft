using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory
{
    public List<InventoryItem> Items;

    public Inventory()
    {
        Items = new List<InventoryItem>();
    }

    public void Add(int ID, string Name, GameObject Model, int Quantity)
    {
        InventoryItem item = Items.Find(x => x.ID == ID);
        if (item == null)
        {
            Items.Add(new InventoryItem(ID, Name, PrefabUtility.GetCorrespondingObjectFromOriginalSource(Model), Quantity));
        }
        else
        {
            item.Quantity += Quantity;
        }
    }

    public void Remove(int ID, int Quantity)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == ID)
            {
                if (Quantity < Items[i].Quantity)
                {
                    Items[i].Quantity -= Quantity;
                }
                else
                {
                    Items.Remove(Items[i]);
                }
            }
        }
    }

    public void Display()
    {
        foreach (InventoryItem item in Items)
        {
            Debug.Log(item.Name + " " + item.Quantity);
        }
    }
}