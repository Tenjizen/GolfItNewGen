using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public static Balle Instance;

    void Awake()
    {
        Instance = this;
    }
}
