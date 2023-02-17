using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    private float distance = 3;
    private float currentX = 0;
    private float currentY = 0;
    //private float sensitivityX = 4;
    //private float sensitivityY = 1;
    private const float Y_ANGLE_MIN = 0;
    private const float Y_ANGLE_MAX = 50;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += -Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * direction;
        camTransform.LookAt(lookAt.position);
    }
}
