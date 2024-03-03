using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // The slider of the health bar
    private Slider BarSlider;
    // The fill of the health bar
    private Image BarFill;
    [SerializeField] private Gradient gradient;
    [SerializeField] private PlayerHealth Player;

    void Start()
    {
        BarSlider = GetComponent<Slider>();
        BarFill = GetComponent<Image>();
        BarSlider.maxValue = PlayerHealth.MAXLIFE;
        BarSlider.value = PlayerHealth.MAXLIFE;
        BarFill.color = gradient.Evaluate(1f);
    }

    void Update()
    {
        BarSlider.value = Player.GetLife();
        BarFill.color = gradient.Evaluate(BarSlider.normalizedValue);
    }
}
