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
        if (sunCounter>=8)
        {
            GameManager.instance.Suns();
            GameManager.instance.GameWin();
        }
    }
}
