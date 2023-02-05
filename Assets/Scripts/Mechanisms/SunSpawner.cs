using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    private ObjectPooling sunPool;
    public Transform spawnPoint;

    public float sunVelocity;
    public float spawnFrecuency;
    private float lastTimeShoot;

    private void Awake()
    {
        sunPool = GetComponent<ObjectPooling>();
    }
    void Update()
    {
        if (CanSpawn()) 
        {
            SpawnSun();
        }        
    }

    public bool CanSpawn()
    {
        if (Time.time - lastTimeShoot >= spawnFrecuency)
            return true;

        return false;
    }
    void SpawnSun()
    {
        lastTimeShoot = Time.time;
        GameObject sun = sunPool.GetObject();
        sun.transform.position = spawnPoint.position;
        sun.transform.rotation = spawnPoint.rotation;
        sun.GetComponent<Rigidbody>().velocity = spawnPoint.forward * sunVelocity;
    }
}
