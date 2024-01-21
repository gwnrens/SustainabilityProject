using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    
    public float temperature = 10.0f;
    public int coins = 4000;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI coinsText;
    private float timer = 0.0f;
    // Voor kolenfabrieken
    private int numberOfCoalFactories = 0;
    public float temperatureIncreasePerMinute = 0.5f;
    public int coinsIncreasePerMinute = 20;
    //voor gasfabriek
    private int numberOfGasFactories = 0;
    public float temperatureIncreasePerMinuteGas = 0.3f; 
    public int coinsIncreasePerMinuteGas = 15;
    //voor zonnepanelen
    private int numberOfSolarPanels = 0;
    public int solarPanelCost = 100; 
    public float temperatureIncreasePerMinuteSolar = 0.1f; 
    public int coinsIncreasePerMinuteSolar = 20;
    //voor kerncentrale
    private int numberOfNuclearPlants = 0;
    public int nuclearPlantCost = 300; // High purchase cost
    public int coinsIncreasePerMinuteNuclear = 100; // High coin production, no temperature increase
    // Voor lampen
    public Light[] lights;

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
            ModifyTemperature((numberOfCoalFactories * temperatureIncreasePerMinute) +
                              (numberOfGasFactories * temperatureIncreasePerMinuteGas) +
                              (numberOfSolarPanels * temperatureIncreasePerMinuteSolar));
       
            ModifyCoins((numberOfCoalFactories * coinsIncreasePerMinute) +
                        (numberOfGasFactories * coinsIncreasePerMinuteGas) +
                        (numberOfSolarPanels * coinsIncreasePerMinuteSolar) +
                        (numberOfNuclearPlants * coinsIncreasePerMinuteNuclear));
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
    //methode voor coalfactory
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
    //methode voor gasfactory
    public void AddGasFactory()
    {
        numberOfGasFactories++;
    }

    public void RemoveGasFactory()
    {
        if (numberOfGasFactories > 0)
        {
            numberOfGasFactories--;
        }
    }
    public int GetNumberOfGasFactories()
    {
        return numberOfGasFactories;
    }
    //methode voor zonnepanelen
    public void AddSolarPanel()
    {
        numberOfSolarPanels++;
    }

    public void RemoveSolarPanel()
    {
        if (numberOfSolarPanels > 0)
        {
            numberOfSolarPanels--;
        }
    }

    public int GetNumberOfSolarPanels()
    {
        return numberOfSolarPanels;
    }
    //methode voor kerncentrale

    // Methods for nuclear plants
    public void AddNuclearPlant()
    {
        numberOfNuclearPlants++;
    }

    public void RemoveNuclearPlant()
    {
        if (numberOfNuclearPlants > 0)
        {
            numberOfNuclearPlants--;
        }
    }

    public int GetNumberOfNuclearPlants()
    {
        return numberOfNuclearPlants;
    }


    //lamp
    public void TurnOffLight()
    {
        ModifyCoins(20); 
    }
}
