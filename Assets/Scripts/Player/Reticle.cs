using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        if (Line.Instance.rb.velocity.magnitude < 0.1f && ready)
        {
            IsSelected = true;
        }
    }
    public void Deselect()
    {
        if (Line.Instance.rb.velocity.magnitude < 0.0001f && ready)
        {
            IsSelected = false;
            Line.Instance.MouseUp();
            CircleCollider.Instance.countShot++;
        }
    }
    private void Update()
    {
        if (!CircleCollider.Instance.restart && CircleCollider.Instance.countShot >= CircleCollider.Instance.shotMax)
        {
            ready = false;
            CircleCollider.Instance.restart = true;

        }
        if (!ready && CircleCollider.Instance.restart && Line.Instance.rb.velocity.magnitude < 0.01f)
        {
            StartCoroutine(RestartLoadScene(5));
        }

    }

    public IEnumerator RestartLoadScene(int n)
    {
        yield return new WaitForSeconds(n);
        Debug.Log("restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
