using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterMeter : MonoBehaviour
{
    [SerializeField] float currentWater, startWater;
    [SerializeField] float speedWaterFalling;
    [SerializeField] Image bar;

    public bool fillingWater;

    [SerializeField] int timeOfFill;

    private void Start()
    {
        currentWater = startWater;
    }

    private void Update()
    {
        bar.fillAmount = currentWater/100;
        if (currentWater>0 && !fillingWater)
        {            
            currentWater -= 1*speedWaterFalling*Time.deltaTime;
        }else if (currentWater<=0)
        {
            GameManager.instance.GameLost();
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
