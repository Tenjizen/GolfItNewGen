using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelCLub : MonoBehaviour
{

    public int ID;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;



    //public GameObject wheel;

    // Start is called before the first frame update
    void Start()
    {

            //wheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    wheel.SetActive(!wheel.activeSelf);
        //}

        if (selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }
    public void Selected() 
    {
        selected = true;
    }
    public void DeSelected() 
    {
        selected = false;

    }

    public void HoverEnter()
    {
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        itemText.text = "";
    }



}


