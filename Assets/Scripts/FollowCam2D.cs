using UnityEngine;

public class FollowCam2D : MonoBehaviour
{

    Camera cam;
    public Transform target;

    public float smoothSpeed = 0.15f;
    public Vector3 velocity = Vector3.zero;
    
    void Start()
    {
        cam = Camera.main;
    }
    void FixedUpdate()
    {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
    }
}
