using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction : MonoBehaviour
{



    public int Force;
    public GameObject DirectionLigne;
    public Text TextForce;
    public GameObject textForce;
    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer.positionCount = 2;
        //Pointer
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {




        Base();
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
        transform.position = Balle.Instance.playerBall.GetComponent<Transform>().position;
        if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            if (Input.GetMouseButton(0))
            {
                Balle.Instance.playerBall.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.left) * Force);
                //right a l'endroit left a l'envers
            }
            //if (Input.GetMouseButton(1))
            //{
            //    if (Force < 2000)
            //        Force += 5;
            //}
            //else if (Input.GetMouseButtonDown(2))
            //    Force = 0;
            //TextForce.text = "Puissance : " + Force / 20 + "%";
            //DirectionLigne.SetActive(true);
            //textForce.SetActive(true);
        }
        //else if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
        //{
        //    //DirectionLigne.SetActive(false);
        //    //textForce.SetActive(false);
        //}
        //pointer escape
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
    }
}
