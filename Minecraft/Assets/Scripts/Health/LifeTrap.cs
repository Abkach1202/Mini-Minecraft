using UnityEngine;

public class LifeTrap : MonoBehaviour, IInteractable
{
  // The damage of the cactus
  [SerializeField] private float Damage;
 
  public void Interact(MonoBehaviour Interactor)
  {
    Interactor.GetComponent<PlayerHealth>().RemoveLife(Damage * Time.deltaTime);
  }
}
