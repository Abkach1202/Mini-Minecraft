using UnityEngine;

public class Resource : MonoBehaviour, IInteractable
{
	// The resource's ID
	[SerializeField] private int ResourceID;
	// The resource's name
	[SerializeField] private string ResourceName;
	// The resource's prefab
	[SerializeField] private GameObject ResourcePrefab;
	// The resource's image
	[SerializeField] private Sprite ResourceSprite;

	// Function to get the resource's ID
	public int GetID()
	{
		return ResourceID;
	}

	// Function to get the resource's name
	public string GetNameResource()
	{
		return ResourceName;
	}

	// Function to get the resource's prefab
	public GameObject GetPrefab()
	{
		return ResourcePrefab;
	}

	// Function to get the resource's image
	public Sprite GetSprite()
	{
		return ResourceSprite;
	}

	// Overriding the Interact function
	public void Interact(MonoBehaviour Interactor, KeyCode Key)
	{
		if (Key == KeyCode.Mouse0)
		{
			Interactor.GetComponent<PlayerInventory>().Collect(this);
			Interactor.GetComponent<PlayerMovement>().AnnulateInteractable();
			gameObject.SetActive(false);
		}
	}
}