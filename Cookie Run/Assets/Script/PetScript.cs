using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{

    public static PetScript instance;
    Animator animator;

    float posx;
    float posy;
    float magneticRange;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        posx = -1.03f;
        posy = 2.39f;
        magneticRange = 1f;
        animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        if (!InGameManager.instance.ismagatic && CooKie.instance != null)
            gameObject.transform.position = new Vector3(CooKie.instance.transform.position.x + posx, CooKie.instance.transform.position.y + posy, transform.position.z);
    }

    public void OnMagneticeffect()
    {
        animator.SetBool("Mag", true);
        gameObject.layer = 8;
        StopCoroutine(MoveToMagpos());
        StartCoroutine(MoveToMagpos());
    }

    public float getMagneticRange()
    {
        return magneticRange;
    }

    IEnumerator MoveToMagpos()
    {
        float time = 0f;
        while (time <= 3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(CooKie.instance.transform.position.x + 6.99f, 0, 0), 0.3f);
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;
        }
        time = 0f;
        animator.SetBool("Mag", false);
        while (time <= 1f)
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, new Vector3(CooKie.instance.transform.position.x + posx, CooKie.instance.transform.position.y + posy, transform.position.z),0.3f);
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;  
        }
        InGameManager.instance.ismagatic = false;
        gameObject.layer = 14;
        
        yield break;
    }
}
