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

    private void Update()
    {        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instance.PlaySFX("Sound Button");
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
        SoundManager.instance.PlaySFX("Sound Button");
        SceneManager.LoadScene("");
    }
    public void OnCreditsButton()
    {
        SoundManager.instance.PlaySFX("Sound Button");
        SceneManager.LoadScene("Credits");
    }
    public void OnOptionsButton()
    {
        SoundManager.instance.PlaySFX("Sound Button");
        optionsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnExitButton()
    {
        SoundManager.instance.PlaySFX("Sound Button");
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnMenuButton()
    {
        SoundManager.instance.PlaySFX("Sound Button");
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

}
