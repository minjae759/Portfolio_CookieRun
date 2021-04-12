using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagedUI : MonoBehaviour
{

    public static DamagedUI instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }

    public void Ondamaged()
    {
        StopCoroutine(Damagedeffect());
        StartCoroutine(Damagedeffect());
    }

    IEnumerator Damagedeffect()
    {
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
    }
}