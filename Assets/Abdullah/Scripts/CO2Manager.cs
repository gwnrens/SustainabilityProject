using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CO2Manager : MonoBehaviour
{
    public Slider co2Slider;
    public TextMeshProUGUI CO2;
    public Healthbar healthbar;
    public TextMeshProUGUI won;
    public GameObject gameOnPanel;
    public GameObject gameOverPanel;
    public GameObject outro;
    public GameObject stats;
    public GameObject player;

    void Start()
    {
        // Set the slider to the max value at start
        co2Slider.maxValue = 100;
        co2Slider.value = co2Slider.maxValue;
        UpdateCO2Text();
    }

    void Update()
    {
        if (healthbar.gameOver)
        {
            if (co2Slider.value <= 40)
            {
                gameOnPanel.SetActive(false);
                gameOverPanel.SetActive(true);
                player.SetActive(false);
                outro.SetActive(true);
                won.text = "JE HEBT GEWONNEN!";
            }
            else
            {
                gameOnPanel.SetActive(false);
                gameOverPanel.SetActive(true);
                player.SetActive(false);
                outro.SetActive(false);
                stats.SetActive(true);
                won.text = "Je hebt verloren!";
            }
        }
    }

    // Call this function to decrease CO2
    public void DecreaseCO2(int amount)
    {
        if (healthbar.gameOver)
        {
            return;
        }
        co2Slider.value = Mathf.Max(co2Slider.value - amount, co2Slider.minValue);
        UpdateCO2Text();
    }

    // Call this function to increase CO2
    public void IncreaseCO2(int amount)
    {
        if (healthbar.gameOver)
        {
            return;
        }
        co2Slider.value = Mathf.Min(co2Slider.value + amount, co2Slider.maxValue);
        UpdateCO2Text();
    }

    private void UpdateCO2Text()
    {
        CO2.text = $"{(co2Slider.value).ToString()}/100";
    }
}
