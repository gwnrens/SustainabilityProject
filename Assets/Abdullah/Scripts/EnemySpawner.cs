using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;
    public int maxEnemies = 200;
    public float spawnRateDecrease = 0.1f;
    public float minimumSpawnRate = 0.5f;
    public bool startSpawning = false;
    public int enemiesSpawned = 0;

    public float intenseSpawnStartTime = 350f; // Time in seconds to start intense spawning
    public float intenseSpawnRate = 0.01f; // Spawn rate during intense phase

    private float nextSpawnTime;
    private int currentEnemyCount;
    private bool intenseSpawningActive = false;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (!startSpawning || enemiesSpawned >= maxEnemies)
        {
            return;
        }

        // Check if it's time to start intense spawning
        if (Time.time >= intenseSpawnStartTime && !intenseSpawningActive)
        {
            spawnRate = intenseSpawnRate; // Set to a much faster spawn rate
            intenseSpawningActive = true; // Flag to indicate intense spawning phase is active
        }

        if (Time.time > nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
            if (!intenseSpawningActive)
            {
                spawnRate = Mathf.Max(spawnRate - spawnRateDecrease, minimumSpawnRate);
            }
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        if (intenseSpawningActive)
        {
            SetEnemyHealth(enemy, 900f); // Set health to 900
        }
        currentEnemyCount++;
        enemiesSpawned++;
    }

    private void SetEnemyHealth(GameObject enemy, float health)
    {
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.startingHealth = health;
            enemyHealth.maxHealth = health;
        }
    }

    public void EnemyDefeated()
    {
        currentEnemyCount--;
    }

    public void StartSpawning()
    {
        startSpawning = true;
    }
}
