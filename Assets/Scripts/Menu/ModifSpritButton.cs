using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModifSpritButton : MonoBehaviour
{
    public Button button;
    public Image imageTest;
    public Sprite Sprite;
    public Sprite OldSprite;

    public void MouseOver()
    {
        AudioManager.Instance.PlaySound("snd_bouton");
        button.image = imageTest;
        imageTest.sprite = Sprite;
    }
    public void MouseExit()
    {
        button.image = imageTest;
        imageTest.sprite = OldSprite;
    }
}
