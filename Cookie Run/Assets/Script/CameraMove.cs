using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float posx = 6.62f;

    // Update is called once per frame
    private void LateUpdate()
    {
        if (CooKie.instance != null && !InGameManager.instance.isGameover)
            transform.position = new Vector3(CooKie.instance.transform.position.x + posx, transform.position.y, transform.position.z);
    }
}
