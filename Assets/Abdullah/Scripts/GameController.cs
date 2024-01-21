using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner[] spawners; 
    public Healthbar healthbar; 
    public TextMeshProUGUI won;
    public GameObject gameOnPanel;
    public GameObject gameOverPanel;
    public GameObject outro;
    public GameObject stats;
    public GameObject player;
    public CO2Manager co2Manager;

    public GameObject explosionPrefab;
    public Camera explosionCamera; 
    public Camera mainCamera; 
    public Transform[] explosionPoints; 

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
            foreach (var spawner in spawners)
            {
                spawner.startSpawning = false; // Stop spawning enemies
            }
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

        Invoke("DestroyExplosions", 7f); // Delay for 7 seconds
    }

    private void DestroyExplosions()
    {
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");

        // Loop door alle explosies en vernietig ze
        foreach (var explosion in explosions)
        {
            Destroy(explosion);
        }

        FinishGameOverSequence();
    }

    private void FinishGameOverSequence()
    {
        if (explosionCamera != null && mainCamera != null)
        {
            explosionCamera.gameObject.SetActive(false);
            mainCamera.gameObject.SetActive(true);
        }

        ShowOutroUI();
    }

    private void ShowOutroUI()
    {
        Time.timeScale = 0;
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
