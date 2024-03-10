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
	[SerializeField] private Sprite ResourceSprite

	public int GetID()
	{
		return ResourceID;
	}

	public string GetNameResource()
	{
		return ResourceName;
	}

	public GameObject GetPrefab()
	{
		return ResourcePrefab;
	}

	public Sprite GetSprite()
  {
  	return ResourceSprite;
  }

	public void Interact(MonoBehaviour Interactor)
	{
		if (Input.GetMouseButtonDown(0))
		{
			Interactor.GetComponent<PlayerInventory>().Collect(this);
			gameObject.SetActive(false);
		}
	}
}