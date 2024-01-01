using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    public Transform[] spawnPoints; // Assign empty GameObjects as spawn points in the Inspector
    public float spawnRate = 2f; // Time in seconds between each spawn
    public int maxEnemies = 200; // Maximum number of enemies to be active at the same time
    public float spawnRateDecrease = 0.1f; // Amount to decrease spawn rate every 10 seconds
    public float minimumSpawnRate = 0.5f; // Minimum spawn rate to ensure it doesn't become too frequent
    public bool startSpawning = false;
    public int enemiesSpawned= 0;

    public int maxEnemiesIncreaseInterval = 30; // Time in seconds to increase maxEnemies
    public int maxEnemiesIncreaseAmount = 1; // Amount to increase maxEnemies
    private float nextMaxEnemiesIncreaseTime;


    public float intenseSpawnStartTime = 300f; // Time in seconds when intense spawning starts
    public float intenseSpawnRate = 0.2f; // Spawn rate during the intense phase
    private bool intenseSpawningActive = false;


    private float nextSpawnTime;
    private int currentEnemyCount;
    private int lastSpawnIndex = -1;
    private int consecutiveSpawns = 0;
    private float nextDecreaseTime;

    public TextMeshProUGUI count;

    public Healthbar healthbar;



    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
        nextDecreaseTime = Time.time + 10f; // Set the first decrease time to 10 seconds after the start
    }

    void Update()
    {
        if (!startSpawning)
        {
            return;
        }

        if (enemiesSpawned == maxEnemies)
        {
            healthbar.gameOver = true;
        }

        if (healthbar.gameOver == true)
        {
            startSpawning = false;
        }

        // Check if it's time to start intense spawning
        if (Time.time >= intenseSpawnStartTime && !intenseSpawningActive)
        {
            spawnRate = intenseSpawnRate; // Set to a much faster spawn rate
            intenseSpawningActive = true; // Flag to indicate intense spawning phase is active
        }

        // Spawning logic
        if (Time.time > nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }

        // Adjust spawn rate over time, but only if not in intense spawn phase
        if (Time.time > nextDecreaseTime && !intenseSpawningActive)
        {
            spawnRate = Mathf.Max(spawnRate - spawnRateDecrease, minimumSpawnRate);
            nextDecreaseTime = Time.time + 10f;
        }

        // Logic to increase max enemies over time
        if (Time.time > nextMaxEnemiesIncreaseTime)
        {
            maxEnemies += maxEnemiesIncreaseAmount;
            nextMaxEnemiesIncreaseTime = Time.time + maxEnemiesIncreaseInterval;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points referenced.");
            enemiesSpawned++;
            return;
        }

        // Select a random spawn point that is not the same as the last one used twice consecutively
        int spawnIndex;
        do
        {
            spawnIndex = Random.Range(0, spawnPoints.Length);
        }
        while (spawnPoints.Length > 1 && spawnIndex == lastSpawnIndex && consecutiveSpawns >= 2);

        if (spawnIndex == lastSpawnIndex)
        {
            consecutiveSpawns++;
        }
        else
        {
            consecutiveSpawns = 1;
            lastSpawnIndex = spawnIndex;
        }

        Transform spawnPoint = spawnPoints[spawnIndex];

        // Instantiate the enemy prefab at the selected spawn point position and rotation
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++;
    }

    // Optional: A method to decrement the enemy count when an enemy is defeated
    public void EnemyDefeated()
    {
        currentEnemyCount--;
        enemiesSpawned++;
    }

    public void StartSpawning()
    {
        startSpawning = true;
    }
}
