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
            texto.text = "Soil Bags " + amount + "/3";
            SoundManager.instance.PlaySFX("Sound Soil");
            Destroy(other.gameObject);
            if (amount == 3)
            {
                GameManager.instance.Soil();
                GameManager.instance.GameWin();
            }
        }
    }


}
