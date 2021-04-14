using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private void OnEnable()
    {
        gameObject.GetComponent<Text>().text = InGameManager.instance.getscore();
    }
}
