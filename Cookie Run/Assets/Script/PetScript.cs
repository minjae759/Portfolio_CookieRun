using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{

    public static PetScript instance;
    
    Animator animator;
    
    GameObject[] gomjellies;
    Vector3 targetpos;

    float posx;
    float posy;
    float magneticRange;
    float abilityTime;
    bool isAbility;
    int gomidx;
    public GameObject gomjellytPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        gomjellies = new GameObject[6];
        gomidx = 0;
        isAbility = false;
        for (int i = 0; i < gomjellies.Length; i++)
        {
            gomjellies[i] = Instantiate(gomjellytPrefab);
            gomjellies[i].SetActive(false);
        }
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
        if (!InGameManager.instance.ismagatic && CooKie.instance != null && !isAbility)
            gameObject.transform.position = new Vector3(CooKie.instance.transform.position.x + posx, CooKie.instance.transform.position.y + posy, transform.position.z);
        if(abilityTime > 2.0f && !isAbility && !InGameManager.instance.ismagatic)
            OnAbility();
        else 
            abilityTime += Time.deltaTime;
    }

    public void OnMagneticeffect()
    {
        animator.SetBool("Mag", true);
        gameObject.layer = 8;
        StopCoroutine(MoveToMagpos());
        StartCoroutine(MoveToMagpos());
    }

    void OnAbility()
    {
        isAbility = true;
        StartCoroutine(MoveToAbilitypos());
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

    IEnumerator MoveToAbilitypos()
    {
        float time = 0f;
        targetpos = InGameManager.instance.GetTargetjellyPos();
        if (targetpos == Vector3.zero)
        {
            isAbility = false;
            abilityTime = 0;
            yield break;
        } 
        while (time <= 0.3f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetpos, 1.0f);
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;
        }
        InGameManager.instance.OffTargetjelly();
        gomjellies[gomidx].SetActive(true);
        gomjellies[gomidx++].transform.position = targetpos;
        if (gomidx > 5) gomidx = 0;
        time = 0f;
        while (time <= 0.3f)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3(CooKie.instance.transform.position.x + posx, CooKie.instance.transform.position.y + posy, transform.position.z), 1.0f);
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;
        }
        isAbility = false;
        abilityTime = 0;
        yield break;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!InGameManager.instance.isGameover)
        {
            if (collision.gameObject.tag == "Boost")
            {
                CooKie.instance.isreinforce = true;
                animator.SetBool("Boost", true);
                CooKie.instance.isboost = true;
                InGameManager.instance.Onboosteffect();
                SFXmanager.instance.PlayOnGetItemJelly();
            }
            if (collision.gameObject.tag == "Bigger")
            {
                CooKie.instance.isreinforce = true;
                CooKie.instance.OnBigger();
                CooKie.instance.isbig = true;
                Invoke("Offbigger", 3f);
            }
            if (collision.gameObject.tag == "Magnetic")
            {
                InGameManager.instance.ismagatic = true;
                OnMagneticeffect();
            }
            if (collision.gameObject.tag == "Potion")
            {
                InGameManager.instance.healhp(0.1f);
                SFXmanager.instance.PlayOnGetItemJelly();
            }
        }
    }
}