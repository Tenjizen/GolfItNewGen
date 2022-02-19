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
        ready = true;
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
        if (!CircleCollider.Instance.restart && CircleCollider.Instance.countShot >= CircleCollider.Instance.shotMax)
        {
            ready = false;
            if (!ready && Line.Instance.rb.velocity.magnitude < 0.0000001f)
            {
                CircleCollider.Instance.restart = true;
                Debug.Log("ready false");
                StartCoroutine(RestartLoadScene());
            }
        }
        //if (restart)
        //{
        //    Debug.Log("restart true");
        //    RestartScene();
        //}
    }
    private void RestartScene()
    {
        StartCoroutine(RestartLoadScene());

    }

    public IEnumerator RestartLoadScene()
    {
        Debug.Log("restart waiting");
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
