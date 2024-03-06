using UnityEngine;

public class StaminaTrap : MonoBehaviour, IInteractable
{
  // The duration of the trap
  [SerializeField] private float TrapDuration;

  public void Interact(MonoBehaviour Interactor)
  {
    PlayerMovement PlayerInteractor = Interactor.GetComponent<PlayerMovement>();
    if (PlayerInteractor.IsBlocked()) return;
    PlayerInteractor.BlockPlayer();
    StartCoroutine(PlayerInteractor.UnblockPlayer(TrapDuration));
  }
}
