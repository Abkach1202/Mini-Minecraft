using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // The slider of the stamina bar
    private Slider BarSlider;
    // The player
    [SerializeField] private PlayerHealth Player;

    void Start()
    {
        BarSlider = GetComponent<Slider>();
        BarSlider.maxValue = PlayerHealth.MAXSTAMINA;
        BarSlider.value = PlayerHealth.MAXSTAMINA;
    }

    void Update()
    {
        BarSlider.value = Player.GetStamina();
    }
}
