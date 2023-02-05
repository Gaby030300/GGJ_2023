using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterObject : MonoBehaviour
{
    public bool filled;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            filled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Base"))
        {
            other.GetComponent<WaterMeter>().FillWater(10);
            filled = false;
        }
    }
}
