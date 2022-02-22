using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject credits;
    public GameObject settings;
    public GameObject keys;




    private void Start()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        keys.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                if (settings.gameObject.activeInHierarchy || credits.gameObject.activeInHierarchy)
                    OnClickPauseMenu();
                else if (keys.gameObject.activeInHierarchy)
                {
                    OnClickBackSettings();
                }
            }
            else if (pauseMenu.gameObject.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }

    public void OnClickCredits()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
    }
    public void OnClickSettings()
    {
        pauseMenu.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(true);
    }
    public void OnClickBackSettings()
    {
        pauseMenu.SetActive(false);
        credits.SetActive(false);
        keys.SetActive(false);
        settings.SetActive(true);
    }
    public void OnClickPauseMenu()
    {
        pauseMenu.SetActive(true);
        credits.SetActive(false);
        settings.SetActive(false);
    }
    public void OnClickKeys()
    {
        settings.SetActive(false);
        keys.SetActive(true);
    }
    public void OnClickLeave()
    {
        Application.Quit();
    }
    public void OnClickResume()
    {
        pauseMenu.SetActive(false);
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
