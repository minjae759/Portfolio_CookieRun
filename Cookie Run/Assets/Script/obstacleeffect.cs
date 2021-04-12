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

    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        isrotate = false;
        isCrashed = false;
    }
    private void Update()
    {
        //나중에 코루틴으로 바꾸기
        if (isrotate)
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + angle * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!InGameManager.instance.isGameover)
        {
            if (collision.gameObject.tag == "Player" && CooKie.instance.isreinforce && !isCrashed)
            {
                isCrashed = true;
                int rot = Random.Range(0, 2);
                if (rot == 1)
                    isrotate = true;
                rigid.constraints = RigidbodyConstraints2D.None;
                rigid.AddForce(Vector2.right * force * Time.deltaTime);
                SoundManager.instance.CrashWithObstacle();
            }
        }     
    }
}
