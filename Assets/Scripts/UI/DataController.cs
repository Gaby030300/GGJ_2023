using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textCounter;
    public static int sunCounter = 0;
    
    void Update()
    {
        textCounter.text = sunCounter.ToString();
    }
}
