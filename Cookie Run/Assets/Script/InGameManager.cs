﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    public Image hpbar;
    public Text jellyScore;
    public GameObject result;

    public GameObject boosteffectPrefab;

    GameObject[] boosteffect;
    int idx;

    static public float speed = 7f;
    public bool isGameover;
    public bool ismagatic;
    int gamescore = 0;
    string strScore = "";


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        boosteffect = new GameObject[20];

        for (int i = 0; i < boosteffect.Length; i++)
        {
            boosteffect[i] = Instantiate(boosteffectPrefab);
            boosteffect[i].SetActive(false);
        }
    }

    private void OnEnable()
    {
        speed = 7f;
    }

    void Start()
    {
        isGameover = false;
        ismagatic = false;
        idx = 0;
    }

    void Update()
    {
        if (isGameover) return;
        hpbar.fillAmount -= 0.02f * Time.deltaTime;

        if (hpbar.fillAmount == 0)
        {
            isGameover = true;
            speed = 0f;
            CooKie.instance.Die();
            SoundManager.instance.PlayOnGameEnd();
            Invoke("OnResult", 2f);
        }
    }

    public void updateScore(int score)
    {
        gamescore += score;
        strScore = string.Format("{0:#,##0}", gamescore);
        jellyScore.text = strScore;
    }

    public void healhp(float percent)
    {
        hpbar.fillAmount += percent;
    }

    public void damagedhp(float percent)
    {
        hpbar.fillAmount -= percent;
    }

    public void GameStop()
    {
        isGameover = true;
        speed = 0f;
        OnResult();
    }

    public void Onboosteffect()
    {
        speed = 12f;
        StopAllCoroutines();
        //StopCoroutine(BoostTime());
        StartCoroutine(BoostTime());
    }

    void Offboosteffect()
    {
        speed = 7f;
        CooKie.instance.Offboost();
        StopCoroutine(BoostTime());
    }

    IEnumerator BoostTime()
    {
        for (int i = 0; i < 50; i++)
        {
            if (idx > boosteffect.Length - 1) idx = 0;
            boosteffect[idx++].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        Offboosteffect();
        yield break;
    }

    void OnResult()
    {
        result.SetActive(true);
    }


    public float getspeed()
    {
        return speed;
    }

    public string getscore()
    {
        return strScore;
    }
}