using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Контроллер камеры
    [SerializeField] public float speedMouse = 300f;
    float xRot = 0f;
    public Transform player;
    float mouseX;
    float mouseY;
    private void Start()
    {
        //player = GameObject.Find("Player").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        //Управление курсором
        mouseX = Input.GetAxis("Mouse X") * speedMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * speedMouse * Time.deltaTime;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -70f, 70f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        player.Rotate(0, mouseX, 0);
        //Приближение камеры по колесику мышки
        Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 100;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 20, 60);
    }
}
