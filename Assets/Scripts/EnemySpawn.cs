using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        float currentInterval =
            Mathf.Max(
                    0.5f,
                    3f -
                    (ScoreManager.Instance.score / 20) * 0.5f
            );
        if(timer >= spawnInterval)
        {
            int spawnCount =
                        1 + (ScoreManager.Instance.score / 60);

            for(int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }
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