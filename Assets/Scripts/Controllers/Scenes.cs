using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    //Контроллер сцен
    public GameObject levelS;
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;

    public GameObject but1;
    public GameObject but2;
    public GameObject but3;
    //public GameObject settingPanel;
    private void Start()
    {
        levelS.SetActive(false);
        //settingPanel.SetActive(false);
    }
    public void Levels()
    {
        levelS.SetActive(true);
        Chapter1();
    }
    public void BackMenuLevels()
    {
        levelS.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Experience1()
    {
        Instruments.SceneLoad("BaseScene");
    }
    public void Chapter1()
    {
        but1.transform.SetAsFirstSibling();
        but2.transform.SetAsLastSibling();
        but3.transform.SetAsLastSibling();
        chapter1.SetActive(true);
        chapter2.SetActive(false);
        chapter3.SetActive(false);
    }
    public void Chapter2()
    {
        but1.transform.SetAsLastSibling();
        but2.transform.SetAsFirstSibling();
        but3.transform.SetAsLastSibling();
        chapter1.SetActive(false);
        chapter2.SetActive(true);
        chapter3.SetActive(false);
    }
    public void Chapter3()
    {
        but1.transform.SetAsLastSibling();
        but2.transform.SetAsLastSibling();
        but3.transform.SetAsFirstSibling();
        chapter1.SetActive(false);
        chapter2.SetActive(false);
        chapter3.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    //public void SettingsON()
    //{
    //    settingPanel.SetActive(!settingPanel.activeSelf);
    //}
    //public void SettingsOFF()
    //{
    //    settingPanel.SetActive(false);
    //}
    //public void SetVolume(float volum)
    //{
    //    AudioListener.volume = volum;
    //}
    //public void QualityLow()
    //{
    //    QualitySettings.SetQualityLevel(0, true);
    //}
    //public void QualityMedium()
    //{
    //    QualitySettings.SetQualityLevel(2, true);
    //}
    //public void QualityUltra()
    //{
    //    QualitySettings.SetQualityLevel(4, true);
    //}
}
