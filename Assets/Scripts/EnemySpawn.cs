using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject midBossPrefab;
    public GameObject warningText;

    public float spawnInterval = 3f;

    private float timer;
    private bool midBossSpawned = false;
    public static EnemySpawner Instance;
    public bool bossBattle = false;

    private void Update()
    {
        timer += Time.deltaTime;

        // スコア60で中ボス出現
        if (
            ScoreManager.Instance.score >= 60 &&
            !midBossSpawned
        )
        {
            midBossSpawned = true;

            StartCoroutine(
                SpawnMidBossSequence()
            );
        }

        // 雑魚敵スポーン
        if (!bossBattle && timer >= spawnInterval)
        {
            int spawnCount =
                1 + (ScoreManager.Instance.score / 60);

            for (int i = 0; i < spawnCount; i++)
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

    private void SpawnMidBoss()
    {
        bossBattle = true;

        //Debug.Log("Boss Spawned");

        Instantiate(
            midBossPrefab,
            new Vector2(5, -4),
            Quaternion.identity
        );
    }

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator SpawnMidBossSequence()
    {
        warningText.SetActive(true);

        yield return new WaitForSeconds(2f);

        warningText.SetActive(false);

        SpawnMidBoss();
    }

    private Vector2 GetRandomSpawnPosition()
    {
        int side = Random.Range(0, 4);

        float distance = 8f;

        switch (side)
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