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

    /*all sound name -> how used
     clip :
        -snd_bonus -> BonusShot
        -snd_bouton -> ModifSpritButton
        -snd_break_box -> Caisse
        -snd_break_wall -> MurCassable
        -snd_collect -> ToCollect
        snd_door_close
        -snd_door_open -> Interaction
        -?snd_ennemy_death1 -> KillEnnemis
        -?snd_hit_man -> KillEnnemis
        -snd_hit_driver -> Line
        -snd_hit_hybride -> Line
        -snd_hit_putter -> Line
        -snd_hit_wedge -> Line
        -?-snd_hit_sandwich1 -> Line
        -?-snd_hit_sandwich2 -> Line
        -snd_interface -> WheelClub
        -snd_jingle_defeat2 -> Reticle
        -snd_jingle_victory -> Hole
        -snd_walk -> CircleCollider
        -snd_wall_hit -> Wall
    music :
        ?snd_menu4
        -snd_game_music 
    */
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