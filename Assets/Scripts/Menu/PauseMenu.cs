using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject pauseMenu;
    public GameObject credits;
    public GameObject settings;
    public GameObject keys;
    private void Start()
    {
        pause.SetActive(false);
        pauseMenu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        keys.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause.gameObject.activeInHierarchy)
            {
                pause.SetActive(true);
                pauseMenu.SetActive(true);
                Reticle.Instance.ready = false;

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
                Reticle.Instance.ready = true;
                pause.SetActive(false);
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
        Reticle.Instance.ready = true;
        Time.timeScale = 1;
        pause.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void OnClickRestart()
    {
        Reticle.Instance.ready = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
