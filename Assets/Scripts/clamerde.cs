using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class clamerde : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image club;
    public Image bonus;


    public static clamerde Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bonus.enabled = false;

        //WheelClubManagement.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ""+CircleCollider.Instance.countShot;
    }
}
