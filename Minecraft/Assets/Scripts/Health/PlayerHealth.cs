using UnityEngine;



public class PlayerHealth : MonoBehaviour
{
    // Max amount of stamina
    public const float MAXSTAMINA = 20;
    // Max amount of life
    public const float MAXLIFE = 20;

    public HealthBar healtthBar;
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
        if (PlayerStamina > MAXSTAMINA) PlayerStamina = MAXSTAMINA;
    }

    public void AddLife(float Life)
    {
        PlayerLife += Life;
        if (PlayerLife > MAXLIFE) PlayerLife = MAXLIFE;
    }

    public void RemoveStamina(float Stamina)
    {
        PlayerStamina -= Stamina;
        if (PlayerStamina < 0) PlayerStamina = 0;
    }

    public void RemoveLife(float Life)
    {
        PlayerLife -= Life;
        healtthBar.SetHealth(PlayerLife);
        if (PlayerLife < 0) PlayerLife = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerLife = MAXLIFE;
        PlayerStamina = MAXSTAMINA;
        healtthBar.SetMaxHealth(MAXLIFE);
        
    }
    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RemoveLife(2);
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(PlayerLife);
        if (collision.gameObject.CompareTag("Cube")) // Vérifie si le gameObject entré en collision est un cube
        {
            RemoveLife(1); // Réduit la vie du joueur lors de la collision avec le cube
        }
    }
}
