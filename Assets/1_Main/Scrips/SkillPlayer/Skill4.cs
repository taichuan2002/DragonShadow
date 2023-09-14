using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation targetBot;
    public Rigidbody2D rb;
    public GameObject[] hitVFX;
    public DataPlayer player;
    float Damecurren;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public void OnInit()
    {
        GameObject targetBotObj = GameObject.FindGameObjectWithTag("Bot");
        if (targetBotObj != null)
        {
            targetBot = targetBotObj.GetComponent<SkeletonAnimation>();
            if (targetBot != null)
            {
                Vector2 targetPosition = (targetBot.transform.position - transform.position).normalized;
                rb.velocity = targetPosition * 20f;
                Invoke(nameof(onDead), 3f);

            }
        }
    }
    public void onDead()
    {
        Destroy(gameObject);
    }
    public void SetDame(float dame)
    {
        Damecurren = dame;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<CharactorEnemy>().OnHit(Damecurren);
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
            GameObject hitvfx3 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            Vector3 largerScale = new Vector2(3, 3);
            hitvfx.transform.localScale = largerScale;
            onDead();
            Destroy(hitvfx, 1);
            Destroy(hitvfx2, 1);
            Destroy(hitvfx3, 1);
        }
    }
}
