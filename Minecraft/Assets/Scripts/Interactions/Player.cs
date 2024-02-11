using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
  private Inventory inventory { get; }

  public Character()
  {
    inventory = new Inventory();
  }

  public void collect(Resource resource)
  {
    inventory.add(resource.id, resource.name, 1);
  }
}