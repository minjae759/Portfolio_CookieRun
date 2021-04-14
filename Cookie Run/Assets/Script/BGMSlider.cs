using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGXvolume");
    }

    public void ValueChanged()
    {
        BGMmanager.instance.ChangeVolume(gameObject.GetComponent<Slider>().value);
    }
}

