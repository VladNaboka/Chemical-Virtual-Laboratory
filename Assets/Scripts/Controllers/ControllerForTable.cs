using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerForTable : MonoBehaviour
{
    public float sensitivityА = 100F;
    float mouseXPos;
    float mouseZPos;

    public Transform table;
    public GameObject piontMouse;
    public Vector3 offset;
    public float sensitivity = 100; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float maxZoom = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    private float X, Y;
    Vector3 move;
    Rigidbody rb;
    void Start()
    {
        piontMouse = GameObject.Find("MouseContr");
        rb = GetComponent<Rigidbody>();

        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(maxZoom) / 2);
        transform.position = table.position + offset;
    }

    void Update()
    {
        mouseXPos = Input.GetAxis("Horizontal");
        mouseZPos = Input.GetAxis("Vertical");
        move = transform.right * mouseXPos + transform.up * mouseZPos;
        rb.velocity = move * 5;
        //Camera.main.transform.LookAt(piontMouse.transform.position);
        if (Input.GetAxis("Mouse ScrollWheel") > 0) 
            offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) 
            offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(maxZoom), -Mathf.Abs(zoomMin));
        if (Input.GetMouseButton(1))
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, limit);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
        }
        transform.position = transform.localRotation * offset + table.position;

        //Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 100;
        //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20, 100);

        //if (Input.mouseScrollDelta.y < 0.0f)
        //    transform.position += Vector3.forward;
        //if (Input.mouseScrollDelta.y > 0.0f)
        //    transform.position -= Vector3.forward;
    }

}
