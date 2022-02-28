using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelClub : MonoBehaviour
{


    public enum PowerClub
    {
        Hybride = 1,
        Putter = 2,
        Driver = 3,
        Wedge = 4,
        Sandwich = 5
    }

    public Line line;
    [SerializeField] private PowerClub club;
    public int powerHybride;
    public int powerPutter;
    public int powerDriver;
    public int powerWedge;
    public int powerSandwitch;
    public GameObject wheel;



    //public bool Hybride = false;
    //public bool Putter = false;
    public bool Driver = false;
    //public bool Wedge = false;
    //public bool Sandwitch = false;


    public static WheelClub Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        wheel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            wheel.SetActive(!wheel.activeSelf);
            if (wheel.activeInHierarchy)
            {
                //AudioManager.Instance.PlaySound("snd_interface");
                Reticle.Instance.ready = false;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                Reticle.Instance.ready = true;
            }
        }
    }




}
