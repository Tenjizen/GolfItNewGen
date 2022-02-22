using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelClubManagement : MonoBehaviour
{
    public WheelClub wheelClub;
    public Line line;
    public WheelClub.PowerClub PowerClub;


    
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Image icon;

    
    public void OnClick()
    {
        Debug.Log(PowerClub);

        switch (PowerClub)
        {
            case WheelClub.PowerClub.Hybride:
                line.minPower = -wheelClub.powerHybride;
                line.maxPower = wheelClub.powerHybride;
                break;
            case WheelClub.PowerClub.Putter:
                line.minPower = -wheelClub.powerPutter;
                line.maxPower = wheelClub.powerPutter;
                break;
            case WheelClub.PowerClub.Driver:
                line.minPower = -wheelClub.powerDriver;
                line.maxPower = wheelClub.powerDriver;
                break;
            case WheelClub.PowerClub.Wedge:
                line.minPower = -wheelClub.powerWedge;
                line.maxPower = wheelClub.powerWedge;
                break;
            case WheelClub.PowerClub.Sandwitch:
                line.minPower = -wheelClub.powerSandwitch;
                line.minPower = wheelClub.powerSandwitch;
                break;
            default:
                break;
        }

    }


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


