using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideButton : MonoBehaviour
{
    public void OnButtonDown()
    {
        CooKie.instance.DownSlideButton();
    }
    public void OnButtonUp()
    {
        CooKie.instance.UpSlideButton();
    }
}
