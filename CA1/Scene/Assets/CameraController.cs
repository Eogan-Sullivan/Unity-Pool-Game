
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(vertical, horizontal, 0);
        horizontal *= Time.deltaTime;
        vertical *= Time.deltaTime;

        float desiredAngleY = target.transform.eulerAngles.y;
       // float desiredAngleX = target.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(0, desiredAngleY, 0);
        transform.position = target.transform.position - (rotation * offset); ;

        transform.LookAt(target.transform);

    }
}
