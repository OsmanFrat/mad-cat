using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int waves = 3;
    public int enemiesPerWave = 5;
    public float spawnDelay = 1f;
    public float waveDelay = 3f;

    private int currentWave = 0;
    private int enemiesSpawned = 0;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(currentWave < waves)
        {
            yield return new WaitForSeconds(waveDelay);

            for(int i = 0; i < enemiesPerWave; i++)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnDelay);
            }

            while(enemiesSpawned > 0)
            {
                yield return null;
            }

            currentWave++;
        }

        Debug.Log("All waves completed!");
    }

    public void EnemyDefeated()
    {
        enemiesSpawned--;
    }
}
