using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool soilBagsCompleted, SunsCompelted;

    public void Suns()
    {
        soilBagsCompleted = true;
    }
    public void Soil()
    {
        SunsCompelted = true;
    }
    public void GameLost()
    {
        Debug.Log("Game Lost");
    }
    public void GameWin()
    {
        if (soilBagsCompleted && SunsCompelted)
        {
            Debug.Log("Game Win");
        }
    }
}
