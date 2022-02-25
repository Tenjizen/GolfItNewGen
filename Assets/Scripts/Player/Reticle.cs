using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Reticle : MonoBehaviour
{
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

 
    private void Update()
    {
        if (!CircleCollider.Instance.restart && CircleCollider.Instance.countShot >= CircleCollider.Instance.shotMax)
        {
            ready = false;
            CircleCollider.Instance.restart = true;
            AudioManager.Instance.PlaySound("snd_jingle_defeat2");

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
