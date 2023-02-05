using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{    
    public GameObject optionsPanel;
    [SerializeField] TextMeshProUGUI textCounter;

    public static int sunCounter = 0;

    private void Update()
    {
        textCounter.text = sunCounter.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.SetActive(!optionsPanel.gameObject.activeSelf);
            if (optionsPanel.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("");
    }
    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnOptionsButton()
    {
        optionsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnExitButton()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
