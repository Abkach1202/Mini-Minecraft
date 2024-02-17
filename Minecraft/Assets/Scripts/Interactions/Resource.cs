using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, Interactable
{
	public int ID;
	public string NameResource;

	public Resource(int ID, string NameResource)
	{
		this.ID = ID;
		this.NameResource = NameResource;
	}

	public void Interact(PlayerInventory interactor)
	{
		interactor.Collect(this);
		Destroy(gameObject);
	}
}