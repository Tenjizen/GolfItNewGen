using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotamouse : MonoBehaviour
{
    Camera Cam;
    float angle;
    Vector2 mousepos;


    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(mousepos.y, mousepos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
    }
}
