using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject[] enemyList;
    public GameObject enemySpawnPoint;
    public int totalWaveCount = 10;
    public int difficultyLevel = 1;
    public int baseEnemyPerWave = 1;
    public float secondsBetweenWaves = 30f;

    public int currentWaveCount = 1;
    public int totalEnemyCount;
    public int currentEnemyCount;
    public int waveEnemyTotal;

    
    // Start is called before the first frame update
    void Start()
    {
        waveEnemyTotal = baseEnemyPerWave + (currentWaveCount * difficultyLevel);
        StartCoroutine(SpawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnWave()
    {
        while(currentWaveCount < totalWaveCount)
        {
            
            
            for(int i = 0; i < waveEnemyTotal; i++)
            {
                int enemyToSpawn = Random.Range(0, enemyList.Length);
                float randomWait = Random.Range(1f, 3f);

                GameObject newEnemy = Instantiate(enemyList[enemyToSpawn], enemySpawnPoint.transform.position, Quaternion.identity);

                totalEnemyCount++;
                currentEnemyCount++;

               // Debug.Log("WaveEnemyTotal: " + waveEnemyTotal + " totalEnemyCount: " + totalEnemyCount);
                
                yield return new WaitForSeconds(randomWait);

            }

            if (totalEnemyCount >= waveEnemyTotal)
            {
                //Debug.Log("Wave populated. wave spawn Delay");
                yield return new WaitForSeconds(secondsBetweenWaves);
                totalEnemyCount = 0;
                currentWaveCount++;
                waveEnemyTotal = baseEnemyPerWave + (currentWaveCount * difficultyLevel);
                //Debug.Log("Delay over. CurrentWaveCount: " + currentWaveCount + "  New enemyWaveTotal: " + waveEnemyTotal);
                
            }
        }
        
    }
}
