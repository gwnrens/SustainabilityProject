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

    private float nextSpawnTime;
    private int currentEnemyCount;

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

        if (Time.time > nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
            spawnRate = Mathf.Max(spawnRate - spawnRateDecrease, minimumSpawnRate);
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++;
        enemiesSpawned++;
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
