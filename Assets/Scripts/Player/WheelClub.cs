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
        Sandwitch = 5
    }


    public Line line;

    [SerializeField] private PowerClub club;


    public Vector2 powerHybride;
    public Vector2 powerPutter;
    public Vector2 powerDriver;
    public Vector2 powerWedge;
    public Vector2 powerSandwitch;


    public GameObject wheel;

    void Start()
    {
        wheel.SetActive(false);
        //line.maxPower = powerDriver;
        //line.minPower = -powerDriver;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            wheel.SetActive(!wheel.activeSelf);
        }

        

    }




}
