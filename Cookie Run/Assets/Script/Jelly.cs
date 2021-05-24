using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int score;
    bool isCrashed;
    float dis;
    Vector3 target;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        isCrashed = false;
        dis = 2.5f;
    }

    private void Update()
    {
        if (InGameManager.instance.ismagatic && !isCrashed)
        {
            target = PetScript.instance.transform.position;
            if (Vector3.Distance(target, transform.position) < dis)
                transform.position = Vector3.MoveTowards(transform.position, target, 0.35f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCrashed)
        {
            isCrashed = true;
            if (collision.gameObject.tag == "Player")
            {
                gameObject.layer = 13;
                InGameManager.instance.updateScore(score);
                SFXmanager.instance.PlayOnGetJelly();
                animator.SetTrigger("Die");
            }
        }
    }

}
