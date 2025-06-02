using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] enemyPrefabs;
    public Transform playerHolder;
    public Transform[] spawnPoints;

    private GameObject currentPlayer;
    private int currentEnemies = 0;

    public float timeToSpawnEnemy = 2f;
    private float currentTime;
    public int maxEnemies = 10;
    public int spawnRange = 10;

    void Start()
    {
        currentPlayer = Instantiate(playerPrefab, playerHolder);
    }

    void Update()
    {
        SpawnMob();
    }

    private void SpawnMob()
    {
        if (currentEnemies >= maxEnemies)
            return;

        currentTime += Time.deltaTime;

        if (currentTime >= timeToSpawnEnemy)
        {
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            float randomX = Random.Range(-spawnRange + spawnPoint.position.x, spawnRange + spawnPoint.position.x);
            float randomZ = Random.Range(-spawnRange + spawnPoint.position.z, spawnRange + spawnPoint.position.z);
            Vector3 randomPosition = new Vector3(randomX, 0.5f, randomZ);

            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            enemy.GetComponent<SeekPlayer>().target = currentPlayer.transform;

            currentEnemies++;
            currentTime = 0;
        }
    }
}
