
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerElec : MonoBehaviour
{
    public Death deathscript;
    public float temperature = 10.0f;
    public int coins = 40;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coalFactoriesText;
    public TextMeshProUGUI gasFactoriesText;
    public TextMeshProUGUI solarPanelsText;
    public TextMeshProUGUI nuclearPlantsText;
    private float timer = 0.0f;
    public GameObject pauseMenuUI;
    public GameObject scoreboardUI;
    public GameObject winUI;

    public bool isGamePaused = false;
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


    private void Update()
    {
        timer += Time.deltaTime;
        Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


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

        temperatureText.text = $"{temperature:F1}°C";
        coinsText.text = $"{coins}";
        coalFactoriesText.text = $": {numberOfCoalFactories}";
        gasFactoriesText.text = $": {numberOfGasFactories}";
        solarPanelsText.text = $": {numberOfSolarPanels}";
        nuclearPlantsText.text = $": {numberOfNuclearPlants}";
        if (temperature >= 20.0f)
        {
            deathscript.Die(); // Call the Die method
        }
        if (numberOfNuclearPlants >= 2)
        {
            WinGame();
        }

    }
    public void ModifyCoins(int amount)
    {
        coins += amount;
        coinsText.text = $"{coins}";
    }

    public void ModifyTemperature(float amount)
    {
        temperature += amount;
        temperatureText.text = $"{temperature:F1}°C";
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
    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); 
        scoreboardUI.SetActive(false); 
        Time.timeScale = 0f; 
        isGamePaused = true;
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        scoreboardUI.SetActive(true); 
        Time.timeScale = 1f; 
        isGamePaused = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false; 
    }
    public void WinGame()
    {
        winUI.SetActive(true); 
        Time.timeScale = 0f; 
        isGamePaused = true; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


}
