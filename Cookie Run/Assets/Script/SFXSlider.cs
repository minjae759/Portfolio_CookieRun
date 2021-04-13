using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public void ValueChanged()
    {
        SFXmanager.instance.ChangeVolume(gameObject.GetComponent<Slider>().value);
    }
}
