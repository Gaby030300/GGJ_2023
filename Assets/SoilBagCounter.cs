using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoilBagCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texto;
    [SerializeField] int amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SoilBag"))
        {
            amount++;
            texto.text = "Soil Bags " + amount + "/10";
            if (amount == 3)
            {
                GameManager.instance.Soil();
                GameManager.instance.GameWin();
            }
        }
    }


}
