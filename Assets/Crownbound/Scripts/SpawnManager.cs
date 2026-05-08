using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int maxEnemies = 5;
    public float spawnDelay = 3f;
    private int enemiesSpawned = 0;
    private float timer;

    void Update()
    {
        // Stop spawning after limit reached
        if (enemiesSpawned >= maxEnemies)
            return;
        timer += Time.deltaTime;
        // Spawn after delay
        if (timer >= spawnDelay)
        {
            timer = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Choose random spawn point
        int randomIndex =
            Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        // Spawn enemy
        Instantiate(
            enemyPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
        enemiesSpawned++;
    }
}
