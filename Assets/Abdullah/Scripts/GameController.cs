using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner[] spawners; // Assign in Inspector
    public Healthbar healthbar; // Assign in Inspector
    public TextMeshProUGUI won;
    public GameObject gameOnPanel;
    public GameObject gameOverPanel;
    public GameObject outro;
    public GameObject stats;
    public GameObject player;
    public CO2Manager co2Manager; // Assign in Inspector

    public GameObject explosionPrefab; // Assign in Inspector
    public Camera explosionCamera; // Assign in Inspector
    public Camera mainCamera; // Assign in Inspector
    public Transform[] explosionPoints; // Assign in Inspector

    private int totalEnemiesToSpawn;
    private int totalEnemiesDead;
    private bool gameOverSequenceStarted = false; // Flag to prevent multiple game over sequences

    void Start()
    {
        totalEnemiesToSpawn = 0;
        foreach (var spawner in spawners)
        {
            totalEnemiesToSpawn += spawner.maxEnemies;
        }
    }

    void Update()
    {
        if (healthbar.gameOver && !gameOverSequenceStarted)
        {
            gameOverSequenceStarted = true; // Set the flag so it doesn't run again
            TriggerGameOverSequence();
        }
    }

    private void TriggerGameOverSequence()
    {
        // Switch to the explosion camera
        if (explosionCamera != null && mainCamera != null)
        {
            explosionCamera.gameObject.SetActive(true);
            mainCamera.gameObject.SetActive(false);
        }

        if (healthbar.slider.value > 0 && co2Manager.co2Slider.value < 40)
        {
            // Trigger explosions once
            if (explosionPrefab != null && explosionPoints != null)
            {
                foreach (var point in explosionPoints)
                {
                    if (point != null)
                    {
                        Instantiate(explosionPrefab, point.position, Quaternion.identity);
                    }
                }
            }
        }

        // Delay handled by a separate method call
        Invoke("DestroyExplosions", 7f); // Delay for 7 seconds
    }

    private void DestroyExplosions()
    {
        // Zoek alle explosie gameobjecten in de scene
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");

        // Loop door alle explosies en vernietig ze
        foreach (var explosion in explosions)
        {
            Destroy(explosion);
        }

        // Roep de functie aan om de gameOverSequence te voltooien
        FinishGameOverSequence();
    }

    private void FinishGameOverSequence()
    {
        // Switch back to the main camera if needed
        if (explosionCamera != null && mainCamera != null)
        {
            explosionCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }

        // Delay showing the outro UI until after the explosions have finished
        ShowOutroUI();
    }

    private void ShowOutroUI()
    {
        explosionCamera.gameObject.SetActive(true);
        // Determine if the player won
        bool wonGame = co2Manager.co2Slider.value <= 40;
        gameOnPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;



        if (wonGame)
        {
            outro.SetActive(true);
            stats.SetActive(false);
            won.text = "JE HEBT GEWONNEN!";
        }
        else
        {
            outro.SetActive(false);
            stats.SetActive(true);
            won.text = "Je hebt verloren!";
        }
    }

    public void SetGameOver()
    {
        if (!gameOverSequenceStarted) // Only set game over if the sequence hasn't started
        {
            healthbar.gameOver = true;
        }
    }

    public void EnemyDied()
    {
        totalEnemiesDead++;
        if (totalEnemiesDead >= totalEnemiesToSpawn && !healthbar.gameOver)
        {
            SetGameOver();
        }
    }
}
