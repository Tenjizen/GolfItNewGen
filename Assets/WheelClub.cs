using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelClub : MonoBehaviour
{

    public Line line;

    [SerializeField] private PowerClub club;


    [SerializeField] private Vector2 powerHybride;
    [SerializeField] private Vector2 powerPutter;
    [SerializeField] private Vector2 powerDriver;
    [SerializeField] private Vector2 powerWedge;
    [SerializeField] private Vector2 powerSandwitch;


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

    enum PowerClub
    {
        Hybride = 1,
        Putter = 2,
        Driver = 3,
        Wedge = 4,
        Sandwitch = 5
    }


}
