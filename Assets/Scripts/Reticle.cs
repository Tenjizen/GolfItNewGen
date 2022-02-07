using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public bool IsSelected = false;

    public static Reticle Instance;
    void Awake()
    {
        Instance = this;
    }
    public void Selected(GameObject selected)
    {
        if (Line.Instance.rb.velocity.magnitude < 0.0001f)
        {
            IsSelected = true;
        }
    }
    public void Deselect()
    {
        if (Line.Instance.rb.velocity.magnitude < 0.0001f)
        {
            IsSelected = false;
            Line.Instance.MouseUp();
        }
    }


}
