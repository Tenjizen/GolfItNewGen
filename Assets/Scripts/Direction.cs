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
        //Pointer
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        


        transform.position = Balle.Instance.playerBall.GetComponent<Transform>().position;
        if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Balle.Instance.playerBall.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.right) * Force);
                //right a l'endroit left a l'envers
            }
            if (Input.GetMouseButton(1))
            {
                if (Force < 4000)
                    Force += 10;
            }
            else if(Input.GetMouseButtonDown(2))
                Force = 0;
            TextForce.text = "Puissance : " + Force/40 +"%";
            DirectionLigne.SetActive(true);
            textForce.SetActive(true);
        }
        else if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
        {
            DirectionLigne.SetActive(false);
            textForce.SetActive(false);
        }
        //pointer escape
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
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
}
