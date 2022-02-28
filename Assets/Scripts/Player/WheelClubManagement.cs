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

    public int myFirstScene, mySecondScene, myThirdScene;

    public Button button;
    public Image imageTest;
    public Image imageLocked;
    [SerializeField] private Sprite locked;

    private bool unlockedDriver = false;
    private bool unlockedPutter = false;
    private bool unlockedWedge = false;
    private bool unlockedSanwich = false;

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
        if (scene.buildIndex >= myFirstScene)
        {
            unlockedDriver = true;
        }

        if (scene.buildIndex >= mySecondScene)
        {
            unlockedPutter = true;
        }
        if (scene.buildIndex >= myThirdScene)
        {
            unlockedWedge = true;
        }
        if (CountToCollect.Instance.toCollect >= isUnlocked)
            unlockedSanwich = true;

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
            case WheelClub.PowerClub.Sandwich:
                if (!unlockedSanwich)
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
            case WheelClub.PowerClub.Sandwich:
                if (unlockedSanwich)
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


