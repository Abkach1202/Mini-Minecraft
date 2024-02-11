using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Interactable
{
	public int id { get; private set; }
	public string name { get; private set; }

	public Resource(int id, string name)
	{
		this.id = id;
		this.name = name;
	}

	public void interact(Character interactor)
	{
		interactor.collect(this);
	}
}