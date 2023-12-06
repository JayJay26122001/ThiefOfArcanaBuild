using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject setPanel;
    public GameObject creditsPanel;
    public Slider masterSlider, musicSlider, vfxSlider;

    void Start()
    {
        GameController.controller.uiController = this;
        SetDefaultValues();
        setPanel.SetActive(false);
        //creditsPanel.SetActive(false);
    }

    void SetDefaultValues()
    {
        AudioController.controller.myMixer.GetFloat("MasterVol", out float aux);
        if (masterSlider != null) masterSlider.value = aux;

        AudioController.controller.myMixer.GetFloat("MusicVol", out float aux2);
        if (musicSlider != null) musicSlider.value = aux2;

        AudioController.controller.myMixer.GetFloat("SfxVol", out float aux3);
        if (vfxSlider != null) vfxSlider.value = aux3;
    }

    public void SettingsButton()
    {
        setPanel.SetActive(true);
    }

    public void ReturnSettingsButton()
    {
        setPanel.SetActive(false);
    }
    public void ReturnCreditsButton()
    {
        creditsPanel.SetActive(false);
    }

    public void CreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMasterVolume()
    {
        if(masterSlider.value > -20)
        {
            AudioController.controller.ChangeMasterVolume(masterSlider.value);
        }
        else
        {
            AudioController.controller.ChangeMasterVolume(-80);
        }
    }

    public void ChangeMusicVolume()
    {
        if (musicSlider.value > -20)
        {
            AudioController.controller.ChangeMusicVolume(musicSlider.value);
        }
        else
        {
            AudioController.controller.ChangeMusicVolume(-80);
        }
    }

    public void ChangeVfxVolume()
    {
        if (vfxSlider.value >= -20)
        {
            AudioController.controller.ChangeVfxVolume(vfxSlider.value);
        }
        else
        {
            AudioController.controller.ChangeVfxVolume(-80);
        }
    }
}
