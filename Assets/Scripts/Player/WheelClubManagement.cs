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
    public Image icon;

    public bool jpp;


    public static WheelClubManagement Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        switch (PowerClub)
        {
            case WheelClub.PowerClub.Hybride:
                selectedItem.sprite = icon.sprite;
                itemText.text = itemName;
                break;
        }
    }

    public void OnClick()
    {

        switch (PowerClub)
        {
            case WheelClub.PowerClub.Hybride:
                line.minPower = -wheelClub.powerHybride;
                line.maxPower = wheelClub.powerHybride;
                //Hybride = true;
                //Putter = false;
                //Driver = false;
                //Wedge = false;
                //Sandwitch = false;
                wheelClub.Driver = false;
                break;
            case WheelClub.PowerClub.Putter:
                line.minPower = -wheelClub.powerPutter;
                line.maxPower = wheelClub.powerPutter;
                //Putter = true;
                //Hybride = false;
                //Driver = false;
                //Wedge = false;
                wheelClub.Driver = false;
                //Sandwitch = false;
                break;
            case WheelClub.PowerClub.Driver:
                line.minPower = -wheelClub.powerDriver;
                line.maxPower = wheelClub.powerDriver;
                wheelClub.Driver = true;
                //Hybride = false;
                //Putter = false;
                //Wedge = false;
                //Sandwitch = false;
                break;
            case WheelClub.PowerClub.Wedge:
                line.minPower = -wheelClub.powerWedge;
                line.maxPower = wheelClub.powerWedge;
                //Wedge = true;
                wheelClub.Driver = false;
                //Hybride = false;
                //Putter = false;
                //Driver = false;
                //Sandwitch = false;
                break;
            case WheelClub.PowerClub.Sandwitch:
                line.minPower = -wheelClub.powerSandwitch;
                line.minPower = wheelClub.powerSandwitch;
                //Sandwitch = true; 
                //Hybride = false;
                wheelClub.Driver = false;
                //Putter = false;
                //Driver = false;
                //Wedge = false;
                break;
            default:
                break;
        }
        selectedItem.sprite = icon.sprite;
        itemText.text = itemName;
    }
}


