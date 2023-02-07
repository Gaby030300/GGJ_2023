using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObject : MonoBehaviour
{
    public bool filled;

    [SerializeField] GameObject filledBucket, unFilledBucket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            SoundManager.instance.PlaySFX("Sound Water");
            unFilledBucket.SetActive(false);
            filledBucket.SetActive(true);
            filled = true;
        }
        if (other.CompareTag("Base") && filled)
        {
            SoundManager.instance.PlaySFX("Sound Water");
            filledBucket.SetActive(false);
            unFilledBucket.SetActive(true);
            other.GetComponent<WaterMeter>().FillWater(10);
            filled = false;
        }
    }    
}
