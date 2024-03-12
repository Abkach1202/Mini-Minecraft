using UnityEngine;

public class LifeTrap : MonoBehaviour, IInteractable
{
  // The damage of the cactus
  [SerializeField] private float Damage;
 
  // Overriding the Interact function
  public void Interact(MonoBehaviour Interactor, KeyCode Key)
  {
    PlayerHealth PlayerHealth = Interactor.GetComponent<PlayerHealth>();
    if (Key == KeyCode.None && PlayerHealth != null)
    {
      PlayerHealth.RemoveLife(Damage * Time.deltaTime);
    }
  }
}
