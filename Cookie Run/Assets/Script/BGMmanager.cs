using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{

    public static BGMmanager instance;

    AudioSource audioSource;

    public AudioClip bgm_Mainlobby;
    public AudioClip bgm_The_Witchs_House;
    public AudioClip bgm_Twisted_Maze_Grove;

    bool isvolumeOn;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        audioSource = GetComponent<AudioSource>();
        if(!PlayerPrefs.HasKey("BGXvolume"))
            PlayerPrefs.SetFloat("BGXvolume", 1.0f);
        audioSource.volume = PlayerPrefs.GetFloat("BGXvolume");
        isvolumeOn = true;
    }

    public void PlayOnMainlobby()
    {
        if (isvolumeOn)
        {
            audioSource.clip = bgm_Mainlobby;
            audioSource.Stop();
            audioSource.Play();
        }
    }
    public void PlayOnChanege()
    {
        if (isvolumeOn)
        {
            audioSource.clip = bgm_Twisted_Maze_Grove;
            audioSource.Stop();
            audioSource.Play();
        }

    }

    public void PlayOnTitle()
    {
        if (isvolumeOn)
        {
            audioSource.clip = bgm_The_Witchs_House;
            audioSource.Stop();
            audioSource.Play();
        }

    }

    public void SoundOn(float value)
    {
        isvolumeOn = true;
        PlayerPrefs.SetFloat("BGXvolume", value);
        audioSource.volume = PlayerPrefs.GetFloat("BGXvolume");
    }

    public void SoundOff()
    {
        isvolumeOn = false;
        PlayerPrefs.SetFloat("BGXvolume", 0.0f);
        audioSource.volume = 0.0f;
        PlayerPrefs.SetFloat("BGXvolume", 0.0f);
    }

    public void ChangeVolume(float value)
    {
        if (isvolumeOn)
        {
            PlayerPrefs.SetFloat("BGXvolume", value);
            audioSource.volume = PlayerPrefs.GetFloat("BGXvolume");
        }
    }
}