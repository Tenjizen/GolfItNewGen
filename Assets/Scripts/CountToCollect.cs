using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountToCollect : MonoBehaviour
{
    public int toCollect = 0;

    public static CountToCollect Instance;



    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
