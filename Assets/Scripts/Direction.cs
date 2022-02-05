using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    public int speedRotation;
    public int Force;
    public GameObject DirectionLigne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Balle.Instance.playerBall.GetComponent<Transform>().position;
        if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude < 0.1)
        {
            transform.Rotate(Vector3.forward * Input.GetAxis("Mouse X") * Time.deltaTime * speedRotation);

            if (Input.GetButtonDown("Fire1"))
            {
                Balle.Instance.playerBall.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.right) * Force);
                //right a l'endroit left a l'envers
            }
            DirectionLigne.SetActive(true);
        }
        else if (Balle.Instance.playerBall.GetComponent<Rigidbody2D>().velocity.magnitude > 0.1)
        {
            DirectionLigne.SetActive(false);
        }

    }
}
