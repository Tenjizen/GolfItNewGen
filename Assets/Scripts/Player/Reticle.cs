using UnityEngine;

public class Reticle : MonoBehaviour
{
    public bool IsSelected = false;
    public bool ready = true;

    


    public static Reticle Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CircleCollider.Instance.countShot = 0;
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
            CircleCollider.Instance.countShot++;
        }
    }
    private void Update()
    {
        if (CircleCollider.Instance.countShot >= CircleCollider.Instance.shotMax)
        {
            ready = false;
        }
    }
}
