using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject spawnType;
    [SerializeField] private float spawnDelay;

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (spawnPoints[i] != null)
                {
                    Instantiate(spawnType, spawnPoints[i].transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnDelay);
                }
            }
        }
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
}