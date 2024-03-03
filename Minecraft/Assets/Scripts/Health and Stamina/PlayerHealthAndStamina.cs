using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    // Max amount of stamina
    public const float MAXSTAMINA = 20;
    // Max amount of life
    public const float MAXLIFE = 20;

    public HealthBar healthBar;

    public StaminaBar staminaBar;
    // The stamina of the player
    private float PlayerLife;
    // The stamina of the player
    private float PlayerStamina;

    public float GetLife()
    {
        return PlayerLife;
    }

    public float GetStamina()
    {
        return PlayerStamina;
    }

    public void AddStamina(float Stamina)
    {
        PlayerStamina += Stamina;
        staminaBar.SetStamina(PlayerStamina);
        if (PlayerStamina > MAXSTAMINA) PlayerStamina = MAXSTAMINA;
    }

    public void AddLife(float Life)
    {
        PlayerLife += Life;
        healthBar.SetHealth(PlayerLife);
        if (PlayerLife > MAXLIFE) PlayerLife = MAXLIFE;
    }

    public void RemoveStamina(float Stamina)
    {
        PlayerStamina -= Stamina;
        staminaBar.SetStamina(PlayerStamina);
        if (PlayerStamina < 0) PlayerStamina = 0;
    }

    public void RemoveLife(float Life)
    {
        PlayerLife -= Life;
        healthBar.SetHealth(PlayerLife);
        if (PlayerLife < 0) PlayerLife = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife = MAXLIFE;
        PlayerStamina = MAXSTAMINA;
        healthBar.SetMaxHealth(MAXLIFE);
        staminaBar.SetMaxStamina(MAXSTAMINA);
    }
    // Update is called once per frame
    void Update()
    {

        if (PlayerLife < MAXLIFE)
        {
            float regenerationRate = 0.5f; // Taux de régénération de la vie par seconde
            AddLife(regenerationRate * Time.deltaTime); // Ajouter la vie en fonction du temps écoulé
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            RemoveLife(2);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(PlayerLife);
        if (collision.gameObject.CompareTag("Cube")) // Vérifie si le gameObject entré en collision est un cube
        {
            RemoveLife(5); // Réduit la vie du joueur lors de la collision avec le cube
        }
    }
}
