using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject settings;
    public GameObject keys;


    public string SceneOne;


    private void Start()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
        keys.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settings.gameObject.activeInHierarchy || credits.gameObject.activeInHierarchy)
                OnClickMainMenu();
            else if (keys.gameObject.activeInHierarchy)
            {
                OnClickBackSettings();
            }
        }
        
    }

    public void OnClickCredits()
    {
        mainMenu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
    }
    public void OnClickSettings()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        settings.SetActive(true);
    }
    public void OnClickBackSettings()
    {
        mainMenu.SetActive(false);
        credits.SetActive(false);
        keys.SetActive(false);
        settings.SetActive(true);
    }
    public void OnClickMainMenu()
    {
        mainMenu.SetActive(true);
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
    public void OnClickPlay()
    {
        SceneManager.LoadScene(SceneOne);
    }
    




}