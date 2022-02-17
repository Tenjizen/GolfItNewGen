using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public List<GameObject> currentCollisions = new List<GameObject>();//test


    private Ennemies _ennemy;

    //public List<GameObject> Ennemies;
    public List<Ennemies> Ennemis;


    public static List Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var ennemy in Ennemis)
        {
            _ennemy = ennemy;
            ennemy.ViewDist = EnnemiFOV.Instance.viewDist;
            
            //ennemy.Killed = false;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(Ennemis[0].ViewDist);
            //Debug.Log(currentCollisions[0].name);
            foreach (var ennemy in Ennemis)
            {
                for (int i = 0; i < Ennemis.Count; i++)
                {
                    Debug.Log(Ennemis[i].ViewDist);
                }
            }
        }
    }
}
[Serializable]
public class Ennemies
{
    public GameObject ennemy;
    public float ViewDist;
    //public bool Killed = false;
}
