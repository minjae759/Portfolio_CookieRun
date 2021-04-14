using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXvolume");
    }

    public void ValueChanged()
    {
        SFXmanager.instance.ChangeVolume(gameObject.GetComponent<Slider>().value);
    }
}
