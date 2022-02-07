using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour
{
    public static MainGame Instance;
    void Awake()
    {
        Instance = this;
    }
}

