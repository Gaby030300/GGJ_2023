using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textSun;

    void Update()
    {
        textSun.text = "SOL: " + SunController.instance.sunCounter;

    }
}
