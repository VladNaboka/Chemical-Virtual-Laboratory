using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject settingPanel;
    public void SettingsON()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
    }
    public void SettingsOFF()
    {
        settingPanel.SetActive(false);
    }
    public void SetVolume(float volum)
    {
        AudioListener.volume = volum;
    }
    public void QualityLow()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    public void QualityMedium()
    {
        QualitySettings.SetQualityLevel(2, true);
    }
    public void QualityUltra()
    {
        QualitySettings.SetQualityLevel(4, true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Instruments.SceneLoad("Menu");
    }
}
