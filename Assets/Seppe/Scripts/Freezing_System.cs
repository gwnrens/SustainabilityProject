using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColdSimulation : MonoBehaviour
{
    public float coldValue = 100f;
    public float maxColdValue = 100f;
    public float decreaseRate = 1f;
    public float rechargeRate = 5f;
    public float dangerMeterIncreaseRate = 10f;
    public float dangerMeterDecreaseRate = 2f;

    //text elementen UI
    public Text coldValueText;     
    public Text dangerMeterText;   
    public Text timerText;         
    public Text gameOverText;
    public Text winText;
    
    public string nextSceneName = "NextScene";     // naam voor volgende scene
    public float restartDelay = 10f;                // delay voor herstarten van het spel
    public float survivalTime = 300f;               // totale duratie van spel

    private bool isRecharging = false;
    private float dangerMeter = 0f;
    private float gameTimer = 0f;

    public GameObject enemyGate;
    public GameObject enemyRoof;
    public GameObject enemyEntrance;
    public GameObject enemyKitchen;
    public GameObject enemyBathroom;
    public GameObject enemyWindow;
    public GameObject enemyDoor;
    public GameObject warmthEffect;

    private float windowClosedTimer = 0f;
    private float resetDangerThreshold = 5f;


    private void Start()
    {
        UpdateColdValueText();
        UpdateDangerMeterText();
        UpdateTimerText();
        HideGameOverText(); // Game over text hiden
        ActivateEnemy(enemyGate);
    }

    private void Update()
    {
        // Game timer optellen
        gameTimer += Time.deltaTime;

        // Decrease warmte value
        coldValue = Mathf.Max(0f, coldValue - decreaseRate * Time.deltaTime);

        // Recharge warmte value
        if (isRecharging)
        {
            RechargeColdValue();
            IncreaseDangerMeter();
        }
        else
        {
            DecreaseDangerMeter();
        }

        float dangerLevel = GameObject.FindObjectOfType<ColdSimulation>().dangerMeter;

        if (dangerLevel >= 25f && enemyGate.activeSelf)
        {
            DeactivateEnemy(enemyGate);
            ActivateRandomEnemy(enemyRoof, enemyEntrance);
        }

        if (dangerLevel >= 50f && (enemyRoof.activeSelf || enemyEntrance.activeSelf))
        {
            DeactivateEnemy(enemyRoof);
            DeactivateEnemy(enemyEntrance);
            ActivateRandomEnemy(enemyKitchen, enemyBathroom);
        }

        if (dangerLevel >= 75f && (enemyKitchen.activeSelf || enemyBathroom.activeSelf))
        {
            DeactivateEnemy(enemyKitchen);
            DeactivateEnemy(enemyBathroom);
            ActivateEnemy(enemyWindow);
        }

        CheckWindowClosed();

        // Check voor game over
        if (coldValue <= 0f || dangerMeter >= 100f)
        {
            GameOver();
        }

        // check dat player nog leeft na 5 minuten
        if (gameTimer >= survivalTime)
        {
            ShowWinText("Proficiat je hebt jezelf warm gehouden en je bent niet gepakt! Bekijk de tips in het pauze menu om thuis ook efficient de verwarming te gebruiken.");
            MoveToNextScene();
        }

        // Update UI
        UpdateColdValueText();
        UpdateDangerMeterText();
        UpdateTimerText();
    }

    private void OnMouseDown()
    {
        // toggle recharging
        isRecharging = !isRecharging;

        if (warmthEffect != null)
        {
            warmthEffect.SetActive(!isRecharging); // Toggle tussen activeren en deactiveren op basis van isRecharging
        }
    }

    private void RechargeColdValue()
    {
        // Recharge warmte meter tot maximum
        coldValue = Mathf.Min(maxColdValue, coldValue + rechargeRate * Time.deltaTime);
    }

    private void IncreaseDangerMeter()
    {
        // Gevaar meter omhoog
        dangerMeter = Mathf.Min(100f, dangerMeter + dangerMeterIncreaseRate * Time.deltaTime);
    }

    private void DecreaseDangerMeter()
    {
        // Verminder gevaar meter
        dangerMeter = Mathf.Max(0f, dangerMeter - dangerMeterDecreaseRate * Time.deltaTime);
    }

    private void UpdateColdValueText()
    {
        // Update UI met warmte meter
        if (coldValueText != null)
        {
            coldValueText.text = "Warmte: " + coldValue.ToString("F0");
        }
    }

    private void UpdateDangerMeterText()
    {
        // Update UI met gevaar meter
        if (dangerMeterText != null)
        {
            dangerMeterText.text = "Gevaar: " + dangerMeter.ToString("F0");
        }
    }

    private void UpdateTimerText()
    {
        // Update UI met timer
        if (timerText != null)
        {
            timerText.text = "Tijd: " + gameTimer.ToString("F0");
        }
    }

    private void ActivateEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(true);
        }
    }

    private void DeactivateEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(false);
        }
    }

    private void ActivateRandomEnemy(GameObject enemy1, GameObject enemy2)
    {
        if (Random.value < 0.5f)
        {
            ActivateEnemy(enemy1);
            DeactivateEnemy(enemy2);
        }
        else
        {
            ActivateEnemy(enemy2);
            DeactivateEnemy(enemy1);
        }
    }

    private bool windowClosed = false;

    private bool dangerResetDone = false;

    private void CheckWindowClosed()
    {
        if (enemyWindow == null)
        {
            // geen error geven als enemy window niet bestaat
            return;
        }

        // rotate objects oproepen
        RotateObject[] rotateObjects = FindObjectsOfType<RotateObject>();

        foreach (RotateObject rotateObject in rotateObjects)
        {
            if (rotateObject != null && rotateObject.rotated)
            {
                Debug.Log("Window Rotated: " + rotateObject.rotated);
                windowClosedTimer = 0f; // Reset timer wanneer de window open is
                windowClosed = false;   // Reset windowClosed
                dangerResetDone = false; // Reset dangerResetDone wanneer window open is
            }
            else
            {
                Debug.Log("Window Closed, Resetting Timer");
                windowClosedTimer += Time.deltaTime;
                windowClosed = true;  // zet windowclosed op true wanneer window gesloten is
                dangerMeter = Mathf.Min(100f, dangerMeter + (dangerMeterIncreaseRate - 5) * Time.deltaTime);

                // Check of window gesloten is voor meer dan 5 seconden
                if (windowClosedTimer >= resetDangerThreshold && windowClosed && !dangerResetDone)
                {
                    if (enemyWindow.activeSelf)
                    {
                        Debug.Log("Resetting Danger Value");
                        // reset danger level met percentage tussen 20 & 45
                        float resetPercentage = Random.Range(20f, 45f);
                        ColdSimulation coldSimulation = FindObjectOfType<ColdSimulation>();
                        coldSimulation.dangerMeter = Mathf.Max(0f, coldSimulation.dangerMeter - resetPercentage);

                        dangerResetDone = true; // Zet danger reset op true zodat dit niet meerdere keren gebeurd

                        // Zet enemy op false nadat danger gereset is
                        enemyWindow.SetActive(false);
                    }
                    else if (enemyWindow.activeSelf && windowClosedTimer >= 15f)
                    {
                        Debug.Log("Setting Danger to 100 because enemyWindow is active for longer than 15 seconds");
                        ColdSimulation coldSimulation = FindObjectOfType<ColdSimulation>();
                        coldSimulation.dangerMeter = 100f;
                    }
                }
            }
        }
    }





    private void GameOver()
    {
        string gameOverMessage = "";

        if (coldValue <= 0f)
        {
            gameOverMessage = "Game Over! Je bent doodgevroren. Zet de verwarming aan volgende keer.";
        }
        else if (dangerMeter >= 100f)
        {
            gameOverMessage = "Game Over! Oh nee, je hebt de verwarming te veel gebruikt en de co-voorzitster van Groen vond dit niet tof. Probeer minder je verwarming te gebruiken om dit te vermijden of sluit het raam om haar weg te houden.";
        }

        ShowGameOverText(gameOverMessage);

        // herstart game na delay
        Invoke("RestartGame", restartDelay);
    }

    private void RestartGame()
    {
        // Herlaad de scene om de game te herstarten
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MoveToNextScene()
    {
        // Laad de volgende scene wanneer 5 minute voorbij zijn gegaan
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void ShowGameOverText(string message)
    {
        if (gameOverText != null)
        {
            gameOverText.text = message;
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void ShowWinText(string message)
    {
        if (winText != null)
        {
            winText.text = message;
            winText.gameObject.SetActive(true);
        }
    }

    private void HideGameOverText()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }
}
