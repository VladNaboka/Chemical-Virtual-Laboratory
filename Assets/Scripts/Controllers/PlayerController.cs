using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float speed = 6f;
    private Rigidbody rb;
    float moveX;
    float moveZ;
    Vector3 move;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Controller();

        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("BaseScene");
    }
    void Controller()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //move = new Vector3(moveX, 0.0f, moveZ);
        move = transform.right * moveX + transform.forward * moveZ;
        rb.velocity = move * speed;
    }
    
}
