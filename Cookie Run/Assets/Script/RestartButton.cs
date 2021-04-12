using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Onclick()
    {
        SoundManager.instance.PlayOnuibutton();
        SceneManager.LoadScene("OvenBreak");
    }
}
