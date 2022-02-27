using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class WheelClubManagement : MonoBehaviour
{
    public WheelClub wheelClub;
    public Line line;
    public WheelClub.PowerClub PowerClub;

    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    public Image icon;

    public string myFirstScene, mySecondScene, myThirdScene;

    public Button button;
    public Image imageTest;
    public Image imageLocked;
    [SerializeField] private Sprite locked;

    private bool unlockedDriver = false;
    private bool unlockedPutter = false;
    private bool unlockedWedge = false;
    private bool unlockedSanwitch = false;

    [SerializeField] private int isUnlocked;

    public static WheelClubManagement Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == myFirstScene)
        {
            unlockedDriver = true;
        }

        else if (scene.name == mySecondScene)
        {
            unlockedPutter = true;
        }
        else if (scene.name == myThirdScene)
        {
            unlockedWedge = true;
        }
        if (CountToCollect.Instance.toCollect >= isUnlocked)
            unlockedSanwitch = true;

        switch (PowerClub)
        {
            case WheelClub.PowerClub.Putter:
                if (!unlockedPutter)
                {
                    button.enabled = false;
                    //button.image.enabled = false;
                    imageLocked.sprite = locked;
                }
                else
                {
                    button.enabled = true;
                    imageLocked.enabled = false;
                }
                break;
            case WheelClub.PowerClub.Driver:
                if (!unlockedDriver)
                {
                    //button.image.enabled = false;
                    button.enabled = false;
                    imageLocked.sprite = locked;
                }
                else
                {
                    button.enabled = true;
                    imageLocked.enabled = false;
                }
                break;
            case WheelClub.PowerClub.Wedge:
                if (!unlockedWedge)
                {
                    //button.image.enabled = false;
                    button.enabled = false;

                    imageLocked.sprite = locked;
                }
                else
                {
                    button.enabled = true;
                    imageLocked.enabled = false;
                }
                break;
            case WheelClub.PowerClub.Sandwitch:
                if (!unlockedSanwitch)
                {
                    button.enabled = false;
                    //button.image.enabled = false;
                    imageLocked.sprite = locked;
                }
                else
                {
                    button.enabled = true;
                    imageLocked.enabled = false;
                }
                break;
            default:
                break;
        }
    }
    public void Init()
    {
        line.power = wheelClub.powerHybride;

        selectedItem.sprite = clamerde.Instance.club.sprite;
    }
    public void OnClick()
    {

        switch (PowerClub)
        {
            case WheelClub.PowerClub.Hybride:
                line.power = wheelClub.powerHybride;
                wheelClub.Driver = false;
                break;
            case WheelClub.PowerClub.Putter:
                if (unlockedPutter)
                {
                    line.power = wheelClub.powerPutter;
                    wheelClub.Driver = false;
                }
                break;
            case WheelClub.PowerClub.Driver:
                if (unlockedDriver)
                {
                    line.power = wheelClub.powerDriver;
                    wheelClub.Driver = true;
                }
                break;
            case WheelClub.PowerClub.Wedge:
                if (unlockedWedge)
                {
                    line.power = wheelClub.powerWedge;
                    wheelClub.Driver = false;
                }
                break;
            case WheelClub.PowerClub.Sandwitch:
                if (unlockedSanwitch)
                {
                    Debug.Log("unloock askip"); 
                    line.power = wheelClub.powerSandwitch;
                    wheelClub.Driver = false;
                }
                break;
            default:
                break;
        }
        selectedItem.sprite = icon.sprite;
        itemText.text = itemName;
    }

    private void OnMouseOver()
    {
        button.image = imageTest;
    }

}


