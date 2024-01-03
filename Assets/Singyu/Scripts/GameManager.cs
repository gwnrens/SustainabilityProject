using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float temperature = 10.0f;
    public int coins = 40;
    public Text temperatureText;
    public Text coinsText;

    public float temperatureIncreaseRate = 0.0f; // Degrees per minute
    public int coalFactoryCost = 40;
    public int coalFactoryTemperatureEffect = 1; // Increase in degrees per minute
    public int coalFactoryCoinProduction = 10; // Coins produced per minute

    private float temperatureTimer = 0.0f;
    private float coinTimer = 0.0f;
    private int numberOfCoalFactories = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (numberOfCoalFactories > 0)
        {
            temperatureTimer += Time.deltaTime;
            if (temperatureTimer >= 60.0f)
            {
                temperatureTimer -= 60.0f;
                temperature += numberOfCoalFactories * temperatureIncreaseRate;
            }

            coinTimer += Time.deltaTime;
            if (coinTimer >= 60.0f)
            {
                coinTimer -= 60.0f;
                coins += numberOfCoalFactories * coalFactoryCoinProduction;
            }
        }

        temperatureText.text = $"Temperature: {temperature:F1}°C";
        coinsText.text = $"Coins: {coins}";
    }

    public void BuyCoalFactory()
    {
        if (coins >= coalFactoryCost)
        {
            coins -= coalFactoryCost;
            numberOfCoalFactories++;
            temperatureIncreaseRate += coalFactoryTemperatureEffect;
        }
    }

    public void SellCoalFactory()
    {
        if (numberOfCoalFactories > 0)
        {
            coins += coalFactoryCost;
            numberOfCoalFactories--;
            temperatureIncreaseRate -= coalFactoryTemperatureEffect;
        }
    }
}
