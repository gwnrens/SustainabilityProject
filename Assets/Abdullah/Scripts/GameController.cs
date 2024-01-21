using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EnemySpawner[] spawners; // Assign all your EnemySpawner objects in the Inspector
    public Healthbar healthbar; // Assign your Healthbar object in the Inspector

    // Panel and UI references
    public TextMeshProUGUI won;
    public GameObject gameOnPanel;
    public GameObject gameOverPanel;
    public GameObject outro;
    public GameObject stats;
    public GameObject player;
    public CO2Manager co2Manager; // Assign the CO2Manager script in the Inspector
    private int totalEnemiesToSpawn;
    private int totalEnemiesDead;

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
        HandleGameOver();
    }

    private void HandleGameOver()
    {
        if (healthbar.gameOver)
        {
            bool wonGame = co2Manager.co2Slider.value <= 40;

            gameOnPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            player.SetActive(false);

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
    }

    public void SetGameOver()
    {
        healthbar.gameOver = true;
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
