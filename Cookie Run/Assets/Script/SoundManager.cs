using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource;

    public AudioClip bgm_Mainlobby;
    public AudioClip bgm_The_Witchs_House;
    public AudioClip bgm_Twisted_Maze_Grove;

    public AudioClip[] getFlyingBearJelly;

    public AudioClip GameStart;
    public AudioClip GameEnd;
    public AudioClip Result;

    public AudioClip getAlphabatJelly;
    public AudioClip getBigBearJelly;
    public AudioClip getBigCoinJelly;
    public AudioClip getGoldJelly;
    public AudioClip getItemJelly;
    public AudioClip getJelly;

    public AudioClip crashWithBody;
    public AudioClip crashWithPower;
    public AudioClip bounceWithObstacle;
    public AudioClip giganticStart;
    public AudioClip giganticEnd;
    public AudioClip giganticLanding;

    public AudioClip jumpClip;
    public AudioClip slideClip;

    public AudioClip uibutton;

    int flyingjellyidx;
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

    private void Start()
    {
        flyingjellyidx = 0;
    }

    public void PlayOnMainlobby()
    {
        if(isvolumeOn)
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

    public void PlayOnGameStart()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(GameStart);
    }

    public void PlayOnGameEnd()
    {
        if (isvolumeOn)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(GameEnd);
        }
    }

    public void PlayOnResult()
    {
        if (isvolumeOn)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Result);
        }
    }

    public void PlayOnGetJelly()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(getJelly);
    }
    

    public void PlayOnGetFlyingBearJelly()
    {
        if (isvolumeOn)
        {
            if (flyingjellyidx >= 6) flyingjellyidx = 0;
            audioSource.PlayOneShot(getFlyingBearJelly[flyingjellyidx++]);
        }
            
    }

    public void PlayOnGetBigBearJelly()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(getBigBearJelly);
    }

    public void PlayOnGetItemJelly()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(getItemJelly);
    }

    public void CrashWithObstacle()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(bounceWithObstacle);
    }

    public void PlayOnCrashWithBody()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(crashWithBody);
    }
    
    public void PlayOnGiganticStart()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(giganticStart);
    }

    public void PlayOnGiganticEnd()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(giganticEnd);
    }
    
    public void PlayOnGiganticLanding()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(giganticLanding);
    }

    public void PlayOnSlideclip()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(slideClip);
    }

    public void PlayOnJumpclip()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(jumpClip);
    }

    public void PlayOnuibutton()
    {
        if (isvolumeOn)
            audioSource.PlayOneShot(uibutton);
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
