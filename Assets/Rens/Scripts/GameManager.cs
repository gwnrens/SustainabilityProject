using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCanvas;
    public GameObject gameEndCanvas;

    public Image Boost1;
    public Image Boost2;
    public Image Boost3;
    public TextMeshProUGUI remainingText;

    public TextMeshProUGUI performanceText;

    private int boosts;
    private bool isRunning;
    private float Car;
    private float Human;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        mainCanvas.SetActive(false);
        gameEndCanvas.SetActive(false);

        Boost1.enabled = false;
        Boost2.enabled = false;
        Boost3.enabled = false;
        remainingText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = player.GetComponent<PlayerMovement>().isRunning;
        boosts = player.GetComponent<PlayerMovement>().numberOfBoosts;
        BoosterSwitch(boosts);
        if (!isRunning)
        {
            mainCanvas.SetActive(false);
            gameEndCanvas.SetActive(true);

            Car = player.GetComponent<PlayerMovement>().CollisionAsCarCounter;
            Human = player.GetComponent<PlayerMovement>().CollisionAsHumanCounter;

            string text = "";

            if (Car==0f)
            {
                text = "Without using the car! Good job";
            }
            if (Human>=Car && Car !=0)
            {
                text = "Mostly on foot";
            }
            if (Car>Human)
            {
                text = "Maybe try to walk more next time...";
            }
            performanceText.text = text;
        }
    }
    private void BoosterSwitch(int aantal)
    {
        if (boosts == 0)
        {
            Boost1.enabled = false;
            Boost2.enabled = false;
            Boost3.enabled = false;
            remainingText.enabled = false;
        }
        if (boosts == 1)
        {
            Boost1.enabled = true;
            Boost2.enabled = false;
            Boost3.enabled = false;
            remainingText.enabled = false;
        }
        if (boosts == 2)
        {
            Boost1.enabled = true;
            Boost2.enabled = true;
            Boost3.enabled = false;
            remainingText.enabled = false;
        }
        if (boosts == 3)
        {
            Boost1.enabled = true;
            Boost2.enabled = true;
            Boost3.enabled = true;
            remainingText.enabled = false;
        }
        if (boosts > 3)
        {
            Boost1.enabled = true;
            Boost2.enabled = true;
            Boost3.enabled = true;
            remainingText.enabled = true;
            remainingText.text = $"+{boosts - 3}";
        }
    }
    
}
