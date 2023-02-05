using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeter : MonoBehaviour
{
    [SerializeField] float currentWater, startWater;
    [SerializeField] float speedWaterFalling;

    public bool fillingWater;

    [SerializeField] int timeOfFill;

    private void Start()
    {
        currentWater = startWater;
    }

    private void Update()
    {
        if (currentWater>0 && !fillingWater)
        {
            currentWater -= 1*speedWaterFalling*Time.deltaTime;
        }
    }

    public void FillWater(float amountToFill)
    {
        fillingWater = true;
        currentWater += amountToFill;
        StartCoroutine(StopFilling());
    }

    IEnumerator StopFilling()
    {
        yield return new WaitForSeconds(timeOfFill);
        fillingWater = false;
    }

}
