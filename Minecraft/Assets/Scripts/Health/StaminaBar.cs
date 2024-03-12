using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
  // The slider of the stamina bar
  private Slider BarSlider;
  // The player Health
  [SerializeField] private PlayerHealth Player;

  // Start is called before the first frame update
  void Start()
  {
    BarSlider = GetComponent<Slider>();
    BarSlider.maxValue = PlayerHealth.MAXSTAMINA;
    BarSlider.value = PlayerHealth.MAXSTAMINA;
  }

  // Update is called once per frame
  void Update()
  {
    BarSlider.value = Player.GetStamina();
  }
}
