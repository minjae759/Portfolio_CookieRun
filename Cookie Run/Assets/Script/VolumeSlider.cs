using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public void ValueChanged()
    {
        SoundManager.instance.ChangeVolume(gameObject.GetComponent<Slider>().value);
    }
}
