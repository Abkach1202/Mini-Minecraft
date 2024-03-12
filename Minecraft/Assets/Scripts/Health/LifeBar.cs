using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
  // The slider of the health bar
  private Slider BarSlider;
  // The fill of the health bar
  [SerializeField] private Image BarFill;
  // The gradient to manage color
  [SerializeField] private Gradient gradient;
  // The player Health
  [SerializeField] private PlayerHealth Player;

  // Start is called before the first frame update
  void Start()
  {
    BarSlider = GetComponent<Slider>();
    BarSlider.maxValue = PlayerHealth.MAXLIFE;
    BarSlider.value = PlayerHealth.MAXLIFE;
    BarFill.color = gradient.Evaluate(1f);
  }

  // Update is called once per frame
  void Update()
  {
    BarSlider.value = Player.GetLife();
    BarFill.color = gradient.Evaluate(BarSlider.normalizedValue);
  }
}
