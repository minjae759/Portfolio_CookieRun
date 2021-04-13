using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    public void ValueChanged()
    {
        BGMmanager.instance.ChangeVolume(gameObject.GetComponent<Slider>().value);
    }
}

