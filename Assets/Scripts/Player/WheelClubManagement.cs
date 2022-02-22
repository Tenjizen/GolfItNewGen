using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelClubManagement : MonoBehaviour
{
    public WheelClub wheelClub;
    public Line line;


    public int ID;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Image icon;



   
    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon.sprite;
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


