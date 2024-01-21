using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CO2Manager : MonoBehaviour
{
    public Slider co2Slider;
    public TextMeshProUGUI CO2;

    void Start()
    {
        // Set the slider to the max value at start
        co2Slider.maxValue = 100;
        co2Slider.value = co2Slider.maxValue;
        UpdateCO2Text();
    }

    // Call this function to decrease CO2
    public void DecreaseCO2(int amount)
    {
        co2Slider.value = Mathf.Max(co2Slider.value - amount, co2Slider.minValue);
        UpdateCO2Text();
    }

    // Call this function to increase CO2
    public void IncreaseCO2(int amount)
    {
        co2Slider.value = Mathf.Min(co2Slider.value + amount, co2Slider.maxValue);
        UpdateCO2Text();
    }

    private void UpdateCO2Text()
    {
        CO2.text = $"{(co2Slider.value).ToString()}/100";
    }
}
