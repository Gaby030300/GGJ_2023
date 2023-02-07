using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    bool soilBagsCompleted, SunsCompelted;

    private void Awake()
    {
        instance = this;
    }

    public void Suns()
    {
        SunsCompelted = true;
    }
    public void Soil()
    {
        soilBagsCompleted = true;
    }
    public void GameLost()
    {
        Debug.Log("Game Lost");
        SceneManager.LoadScene("Lost");
    }
    public void GameWin()
    {       
        if (SunsCompelted && soilBagsCompleted)
        {
            SceneManager.LoadScene("Win");
            Debug.Log("Game Win");
        }
    }
}
