using UnityEngine;

public class Reticle : MonoBehaviour
{
    public bool IsSelected = false;
    public bool ready = true;

    public static Reticle Instance;
    void Awake()
    {
        Instance = this;
    }
    public void Selected(GameObject selected)
    {
        if (Line.Instance.rb.velocity.magnitude < 0.01f && ready == true)
        {
            IsSelected = true;
        }
    }
    public void Deselect()
    {
        if (Line.Instance.rb.velocity.magnitude < 0.0000001f && ready == true)
        {
            IsSelected = false;
            Line.Instance.MouseUp();
        }
    }
}
