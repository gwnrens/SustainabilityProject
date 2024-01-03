using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float temperature = 10.0f;
    public int coins = 40;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI coinsText;

    private float timer = 0.0f;
    private int numberOfCoalFactories = 0;

    public float temperatureIncreasePerMinute = 0.5f;
    public int coinsIncreasePerMinute = 20;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;

  
        if (timer >= 60.0f)
        {
            timer -= 60.0f;
            ModifyTemperature(numberOfCoalFactories * temperatureIncreasePerMinute);
            ModifyCoins(numberOfCoalFactories * coinsIncreasePerMinute);
        }

        temperatureText.text = $"Temperatuur: {temperature:F1}°C";
        coinsText.text = $"Munten: {coins}";
    }

    public void ModifyCoins(int amount)
    {
        coins += amount;
        coinsText.text = $"Munten: {coins}";
    }

    public void ModifyTemperature(float amount)
    {
        temperature += amount;
        temperatureText.text = $"Temperatuur: {temperature:F1}°C";
    }

    public void AddCoalFactory()
    {
        numberOfCoalFactories++;
    }

    public void RemoveCoalFactory()
    {
        if (numberOfCoalFactories > 0)
        {
            numberOfCoalFactories--;
        }
    }
}
