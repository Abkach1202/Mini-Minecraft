using UnityEngine;

public class StaminaTrap : MonoBehaviour, IInteractable
{
  // The duration of the trap
  [SerializeField] private float TrapDuration;

  // Overriding the Interact function
  public void Interact(MonoBehaviour Interactor, KeyCode Key)
  {
    PlayerMovement PlayerMovement = Interactor.GetComponent<PlayerMovement>();
    if (Key == KeyCode.None && PlayerMovement != null && !PlayerMovement.IsBlocked())
    {
      PlayerMovement.BlockPlayer();
      StartCoroutine(PlayerMovement.UnblockPlayer(TrapDuration));
    }
  }
}
