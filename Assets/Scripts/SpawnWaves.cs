using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWaves : MonoBehaviour
{
    [HideInInspector]
    public bool isAlive = true;

    public GameObject hazard;
    public GameObject enemy;
    public GameObject boss;
    public Vector3 spawnAsteroid, spawnEvemy, spawnBoss;
    public float spawnTime;
    public float startTime;
    public float waveTime;
    public int spawnCount;
    [HideInInspector]
    public bool isEndOfWave = false;
    [HideInInspector]
    public int count = 0;
    [HideInInspector]
    public bool isEndless = true;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {

    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(startTime);
        for (int i = 0; i < spawnCount; i++)
        {
            int a = Random.Range(1, 3);
            if (a == 1)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnAsteroid.x, spawnAsteroid.x), spawnAsteroid.y, spawnAsteroid.z);
                Instantiate(hazard, spawnPosition, new Quaternion()).GetComponent<DestroyByShot>().setGameController(gameObject);

                yield return new WaitForSeconds(spawnTime);
            }
            else
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnEvemy.x, spawnEvemy.x), spawnEvemy.y, spawnEvemy.z);
                Instantiate(enemy, spawnPosition, Quaternion.Euler(0, 180, 0)).GetComponent<DestroyByShot>().setGameController(gameObject);

                yield return new WaitForSeconds(spawnTime);
            }
        }
        yield return new WaitForSeconds(waveTime);
        Boss();

    }

    void Boss()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnBoss.x, spawnBoss.x), spawnBoss.y, spawnBoss.z);
        Instantiate(boss, spawnPosition, Quaternion.Euler(0, 180, 0)).GetComponent<BossDestroy>().setGameController(gameObject);
        isEndOfWave = false;
    }

    IEnumerator EndlessSpawn()
    {
        yield return new WaitForSeconds(startTime);
        while (isAlive)
        {
            if (!isEndOfWave)
            {
                int a = Random.Range(1, 3);
                if (a == 1)
                {
                    count++;
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnAsteroid.x, spawnAsteroid.x), spawnAsteroid.y, spawnAsteroid.z);
                    Instantiate(hazard, spawnPosition, new Quaternion()).GetComponent<DestroyByShot>().setGameController(gameObject);
                    yield return new WaitForSeconds(spawnTime);
                }
                else
                {
                    count++;
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnEvemy.x, spawnEvemy.x), spawnEvemy.y, spawnEvemy.z);
                    Instantiate(enemy, spawnPosition, Quaternion.Euler(0, 180, 0)).GetComponent<DestroyByShot>().setGameController(gameObject);
                    yield return new WaitForSeconds(spawnTime);
                }
                if (count == 20)
                    yield return new WaitForSeconds(waveTime);
                if (count == 100)
                {
                    count++;
                    Boss();
                    isEndOfWave = true;
                }
            }
        }
    }

    public void Spawn()
    {
        if (isEndless)
        {
            StartCoroutine(EndlessSpawn());
        }
        else StartCoroutine(SpawnWave());
    }
}