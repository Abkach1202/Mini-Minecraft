using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  // Max amount of stamina
  public const float MAXSTAMINA = 20;
  // Max amount of life
  public const float MAXLIFE = 20;

  // The life of the player
  private float PlayerLife;
  // The stamina of the player
  private float PlayerStamina;
  // The life generation of the player
  [SerializeField] private float PlayerLifeGeneration;

  // Start is called before the first frame update
  void Start()
  {
    PlayerLife = MAXLIFE;
    PlayerStamina = MAXSTAMINA;
  }

  // Function to get the life of the player
  public float GetLife()
  {
    return PlayerLife;
  }

  // Function to get the stamina of the player
  public float GetStamina()
  {
    return PlayerStamina;
  }

  // Function to add stamina to the player
  public void AddStamina(float Stamina)
  {
    PlayerStamina += Stamina;
    if (PlayerStamina > MAXSTAMINA) PlayerStamina = MAXSTAMINA;
  }

  // Function to add life to the player
  public void AddLife(float Life)
  {
    PlayerLife += Life;
    if (PlayerLife > MAXLIFE) PlayerLife = MAXLIFE;
  }

  // Function to remove stamina to the player
  public void RemoveStamina(float Stamina)
  {
    PlayerStamina -= Stamina;
    if (PlayerStamina < 0) PlayerStamina = 0;
  }

  // Function to remove life to the player
  public void RemoveLife(float Life)
  {
    PlayerLife -= Life;
    if (PlayerLife < 0) PlayerLife = 0;
  }

  // Update is called once per frame  
  void Update()
  {
    if (PlayerLife < MAXLIFE)
    {
      AddLife(PlayerLifeGeneration * Time.deltaTime);
    }
  }
}
