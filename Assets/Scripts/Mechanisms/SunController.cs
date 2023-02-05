using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SunController : MonoBehaviour
{
    public float activeTime;
    private float spawnTime;    

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
            DataController.sunCounter++;
        }
        else if (other.CompareTag("Ground"))
        {
            Debug.Log("Toco Suelo");
        }

        gameObject.SetActive(false);
    }

}
