using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonWin : MonoBehaviour
{
    public Experience1 ex1;
    public Experience2 ex2;

    public AddingLiquid addingLiquid;

    public GameObject winLab1;

    public GameObject player;
    public CameraController cameraContr;

    float timer = 7f;
    private void Start()
    {
        winLab1.SetActive(false);
    }
    void Update()
    {
        if (ex1.activFenilftalein && addingLiquid.activPill && ex2.activTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.1f)
            {
                winLab1.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<Rigidbody>().isKinematic = true;
                cameraContr.speedMouse = 0f;
            }
               
        }
    }
}
