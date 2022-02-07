using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordel : MonoBehaviour
{


    /*public GameObject DirectionLigne;


    void Start()
    {

    }

    void Update()
    {
        //Base();
        //FaceMouse();
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
        transform.position = Clickable.Instance.playerBall.GetComponent<Transform>().position;
        if (Clickable.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            if (Input.GetMouseButton(0))
            {
                Clickable.Instance.playerBall.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.left) * Force);
                //right a l'endroit left a l'envers
            }
        }

    }*/
}
