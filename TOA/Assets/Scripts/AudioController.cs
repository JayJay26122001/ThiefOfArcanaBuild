using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController controller;
    public AudioClip[] myMusic;
    private AudioSource gameMusic;
    public AudioMixer myMixer;
    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        gameMusic = GetComponent<AudioSource>();
    }
    public void ChangeMusic(string scene)
    {
        switch (scene)
        {
            case "TelaInicial":
                gameMusic.clip = myMusic[0];
                break;

            case "Game":
                gameMusic.clip = myMusic[1];
                break;

            case "Derrota":
                gameMusic.clip = myMusic[2];
                break;

            case "Tutorial":
                gameMusic.clip = myMusic[3];
                break;
        }
        gameMusic.Play();
    }

    public void ChangeMasterVolume(float volume)
    {
        myMixer.SetFloat("MasterVol", volume);
    }
    public void ChangeMusicVolume(float volume)
    {
        myMixer.SetFloat("MusicVol", volume);
    }
    public void ChangeVfxVolume(float volume)
    {
        myMixer.SetFloat("SfxVol", volume);
    }
}

