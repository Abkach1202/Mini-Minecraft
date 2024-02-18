using UnityEngine;

public class Resource : MonoBehaviour, IInteractable
{
	// The resource's ID
	[SerializeField] private int ResourceID;
	// The resource's name
	[SerializeField] private string ResourceName;
	// The resource's prefab
	[SerializeField] private GameObject ResourcePrefab;

	public int GetID() {
		return ResourceID;
	}

	public string GetNameResource() {
		return ResourceName;
	}

	public GameObject GetPrefab() {
		return ResourcePrefab;
	}

	public void Interact(PlayerInventory Interactor)
	{
		Interactor.Collect(this);
		gameObject.SetActive(false);
	}
}