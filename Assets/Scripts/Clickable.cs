using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{

    [SerializeField] private Reticle reticleManager;

    public static Clickable Instance;
    void Awake()
    {
        Instance = this;
    }
    private void OnMouseDown()
    {

        reticleManager.Selected(this.gameObject);

    }

    private void OnMouseUp()
    {
        reticleManager.Deselect();
    }

}
