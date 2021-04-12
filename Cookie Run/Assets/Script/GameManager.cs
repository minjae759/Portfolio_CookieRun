using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 60;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "OvenBreak")
        {
            Time.timeScale = 1;
            SoundManager.instance.PlayOnChanege();
        }
        if (scene.name == "login")
        {
            Time.timeScale = 1;
            SoundManager.instance.PlayOnTitle();
        }
        if (scene.name == "mode_select")
        {
            Time.timeScale = 1;
            SoundManager.instance.PlayOnMainlobby();
        }

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
