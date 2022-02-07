using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordel : MonoBehaviour
{


    public GameObject DirectionLigne;


    void Start()
    {

    }

    void Update()
    {
        Base();
        FaceMouse();
    }
    private void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
            );
        transform.right = direction;
    }
    private void Base()
    {
        transform.position = MainGame.Instance.playerBall.GetComponent<Transform>().position;
    }
}
