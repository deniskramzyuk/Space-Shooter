using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    public float fireRate;
    private float fireTime;
    private float firstFireTime;
    public GameObject shot;
    public Transform shotSpawn;


    private void Start()
    {
        firstFireTime = Random.Range(2f, 4f);
        fireTime =Time.time + firstFireTime+fireRate;
        Invoke("Fire", firstFireTime);
    }

    void Update () {

        if (Time.time >= fireTime)
        {
            Fire();
        }
		
	}


    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation).GetComponent<DestroyByRestart>().setGameController(GetComponent<DestroyByShot>().GameController);
        fireTime = Time.time + fireRate;
        GetComponent<AudioSource>().Play();
    }
}
