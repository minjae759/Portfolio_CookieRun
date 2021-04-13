using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooKie : MonoBehaviour
{
    public static CooKie instance;

    bool isGround = true;
    public bool isboost;
    public bool isbig;
    public bool isreinforce = false;

    private int jump = 2;
    private float jumpforce = 460.0f;

    Animator animator;
    Rigidbody2D rigidbody;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isbig = false;
        isboost = false;
    }

    void Update()
    {
        if (InGameManager.instance.isGameover) return;
        gameObject.transform.Translate(Vector3.right * InGameManager.instance.getspeed() * Time.deltaTime);
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        rigidbody.velocity = Vector2.zero;
    }

    public void OnClickJumpButton()
    {
        if (isGround && !InGameManager.instance.isGameover)
        {
            isGround = false;
            animator.SetBool("Grounded", false);
            animator.SetBool("Jump", true);
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(0, jumpforce));
            jump--;
        }
        else if (!isGround && jump == 1 && !InGameManager.instance.isGameover)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Jump2", true);
            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(new Vector2(0, jumpforce));
            jump--;
        }
    }

    public void DownSlideButton()
    {
        animator.SetBool("Slide", true);
    }

    public void UpSlideButton()
    {
        animator.SetBool("Slide", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = 2;
            isGround = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Jump2", false);
            animator.SetBool("Grounded", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!InGameManager.instance.isGameover)
        {
            if (collision.gameObject.tag == "Boost")
            {
                isreinforce = true;
                animator.SetBool("Boost", true);
                isboost = true;
                InGameManager.instance.Onboosteffect();
                SFXmanager.instance.PlayOnGetItemJelly();
            }
            if (collision.gameObject.tag == "Bigger")
            {
                isreinforce = true;
                OnBigger();
                isbig = true;
                Invoke("Offbigger", 3f);
            }
            if (collision.gameObject.tag == "Magnetic")
            {
                InGameManager.instance.ismagatic = true;
                PetScript.instance.OnMagneticeffect();
            }
            if (collision.gameObject.tag == "Obstacle" && !isreinforce)
            {
                animator.SetTrigger("Hurt");
                InGameManager.instance.damagedhp(0.03f);
                SFXmanager.instance.PlayOnCrashWithBody();
                StopCoroutine(invincibilityeffect());
                StartCoroutine(invincibilityeffect());
                DamagedUI.instance.Ondamaged();
            }
            if (collision.gameObject.tag == "Potion")
            {
                InGameManager.instance.healhp(0.1f);
                SFXmanager.instance.PlayOnGetItemJelly();
            }
        }
    }

    public void OnBigger()
    {
        StopCoroutine(biggerscale());
        StartCoroutine(biggerscale());
    }

    void Offbigger()
    {
        isbig = false;
        StopCoroutine(smallerscale());
        StartCoroutine(smallerscale());
        StopCoroutine(invincibilityeffect());
        StartCoroutine(invincibilityeffect());
    }

    public void Offboost()
    {
        isreinforce = false;
        isboost = false;
        animator.SetBool("Boost", false);
        StopCoroutine(invincibilityeffect());
        StartCoroutine(invincibilityeffect());
    }

    IEnumerator biggerscale()
    {
        float time = 0f;
        SFXmanager.instance.PlayOnGiganticStart();
        while (time <= 1f)
        {
            yield return new WaitForSeconds(0.001f);
            time += Time.deltaTime * 2f;
            gameObject.transform.localScale = new Vector3(2f + time, 2f + time, 1f);
        }
        gameObject.transform.localScale = new Vector3(3f, 3f, 1f);

    }

    IEnumerator smallerscale()
    {
        float time = 0f;
        SFXmanager.instance.PlayOnGiganticEnd();
        while (time <= 1f)
        {
            yield return new WaitForSeconds(0.001f);
            time += Time.deltaTime * 2f;
            gameObject.transform.localScale = new Vector3(3f - time, 3f - time, 1f);
        }
        gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
    }

    IEnumerator invincibilityeffect()
    {
        if (isbig || isboost) yield break;
        gameObject.layer = 11;
        isreinforce = false;
        for (int i = 0; i < 5; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.3f);
        }
        gameObject.layer = 8;
        yield break;
    }
}
