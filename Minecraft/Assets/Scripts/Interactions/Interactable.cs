using UnityEngine;

public interface IInteractable
{
  // Function to interact with the Interactable
  public void Interact(MonoBehaviour Interactor, KeyCode Key);
}