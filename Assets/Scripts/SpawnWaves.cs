using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWaves : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnWave());
    }


    public GameObject hazard;
    public Vector3 spawn;
    public float spawnTime;
    public float startTime;
    public float waveTime;
    public int spawnCount;

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawn.x, spawn.x), spawn.y, spawn.z);
                Quaternion spawnRotation = new Quaternion();
                Instantiate(hazard, spawnPosition, spawnRotation).GetComponent<DestroyByShot>().setGameController(gameObject);

                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(waveTime);
        }
    }
}