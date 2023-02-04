using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public float activeTime;
    private float spawnTime;
    public int sunCounter = 0;

    public static SunController instance;

    private void OnEnable()
    {
        spawnTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - spawnTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Toco Player");
            sunCounter++;
            Debug.Log(sunCounter);
        }
        else if (other.CompareTag("Ground"))
        {
            Debug.Log("Toco Suelo");
        }

        gameObject.SetActive(false);
    }

}
