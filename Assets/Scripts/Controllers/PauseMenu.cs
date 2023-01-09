using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Меню паузы
    public GameObject pausemenu;
    public GameObject player;
    public CameraController cameraContr;
    bool activatorPMenu = false;
    private void Start()
    {
        pausemenu.SetActive(false);
        //CameraContr = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        //По нажитии ESC будет активироваться или дизактивироваться меню паузы
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activatorPMenu = !activatorPMenu;
            if (activatorPMenu)
            {
                pausemenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<Rigidbody>().isKinematic = true;
                cameraContr.speedMouse = 0f;
            }
            if(!activatorPMenu)
            {
                pausemenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<Rigidbody>().isKinematic = false;
                cameraContr.speedMouse = 300f;
            }
        } 
    }
    //Для работы кнопок в меню паузы
    public void MainMenu()
    {
        Instruments.SceneLoad("Menu");
        Cursor.lockState = CursorLockMode.None;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        
    }
}
