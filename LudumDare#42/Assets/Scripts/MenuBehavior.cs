using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    public void Awake()
    {
        VolumeController.value = SettingsManager.volume;
    }
    float volumeDefault = 0.5f;
    public Slider VolumeController;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void VolumeChange()
    {
        SettingsManager.Volume(VolumeController.value);
    }

    public void VolumeDefault()
    {
        VolumeController.value = volumeDefault;
        VolumeChange();
    }
}
