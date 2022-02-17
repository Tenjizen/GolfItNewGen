using UnityEngine;

public class FollowCam2D : MonoBehaviour
{

    private Camera cam;

    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.15f;
    [SerializeField] private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
    }
}
