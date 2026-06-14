using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = GetRandomSpawnPosition();

        Instantiate(
            enemyPrefab,
            spawnPos,
            Quaternion.identity
        );
    }

    private Vector2 GetRandomSpawnPosition()
    {
        int side = Random.Range(0, 4);

        float distance = 8f;

        switch(side)
        {
            case 0:
                return new Vector2(
                    Random.Range(-distance, distance),
                    distance
                );

            case 1:
                return new Vector2(
                    Random.Range(-distance, distance),
                    -distance
                );

            case 2:
                return new Vector2(
                    -distance,
                    Random.Range(-distance, distance)
                );

            default:
                return new Vector2(
                    distance,
                    Random.Range(-distance, distance)
                );
        }
    }
}