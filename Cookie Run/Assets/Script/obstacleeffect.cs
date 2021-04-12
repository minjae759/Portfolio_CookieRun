using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleeffect : MonoBehaviour
{

    Rigidbody2D rigid;
    float angle = -700.0f;
    float force = 40000.0f;
    bool isrotate;
    bool isCrashed;
    int rot;

    void Start()
    {
        rot = Random.Range(0, 2);
        rigid = this.GetComponent<Rigidbody2D>();
        isrotate = false;
        isCrashed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!InGameManager.instance.isGameover)
        {
            if (collision.gameObject.tag == "Player" && CooKie.instance.isreinforce && !isCrashed)
            {
                isCrashed = true;
                StopCoroutine(Onrotate());
                StartCoroutine(Onrotate());
                rigid.constraints = RigidbodyConstraints2D.None;
                rigid.AddForce(Vector2.right * force * Time.deltaTime);
                SoundManager.instance.CrashWithObstacle();
            }
        }     
    }
    IEnumerator Onrotate()
    {
        float time = 0f;
        while(time <= 3f)
        {
            yield return new WaitForSeconds(0.01f);
            time += Time.deltaTime;
            if (rot == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angle * Time.deltaTime);
            }
        }
        gameObject.SetActive(false);
    }
}
