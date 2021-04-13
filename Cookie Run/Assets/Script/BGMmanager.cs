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
        audioSource.volume = 0.5f;
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
        audioSource.volume = value * 0.5f;
    }

    public void SoundOff()
    {
        isvolumeOn = false;
        audioSource.volume = 0.0f;
    }

    public void ChangeVolume(float value)
    {
        if (isvolumeOn)
            audioSource.volume = value * 0.5f;
    }
}