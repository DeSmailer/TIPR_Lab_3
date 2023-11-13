using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    [SerializeField] private HP _hp;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _hp.OnHPChange += Display;
        Display();
    }

    private void Display()
    {
        _slider.value = (float)_hp.CurrentHP / (float)_hp.MaxHP;
    }

    private void OnDestroy()
    {
        _hp.OnHPChange -= Display;
    }
}
