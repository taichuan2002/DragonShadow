using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;

public class Skill2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject hitVFXDead;
    public DataPlayer player;
    public float speed = 5f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
   
    public void OnInit()
    {
        float randomY = UnityEngine.Random.Range(-1, 1);
        int randomDecimalPart = UnityEngine.Random.Range(0, 10);
        randomY += randomDecimalPart * 0.1f;
        Vector2 point = new Vector2(transform.position.x + 11,transform.position.y + randomY);
        transform.LookAt(transform.position);
        if(randomY > 0.2)
        {
            this.transform.DOJump(point, 1, 1, speed).OnComplete(() =>
            {
                rb.velocity = transform.right * 20;
            });
            Invoke(nameof(OnDead), 3);
        }
        else if(randomY < -0.2)
        {
            this.transform.DOJump(point, -0.5f, 1, speed).OnComplete(() =>
            {
                rb.velocity = transform.right * 20;
            });
            Invoke(nameof(OnDead), 3);
        }
        else
        {
            this.transform.DOJump(point, 0, 1, speed).OnComplete(() =>
            {
                rb.velocity = transform.right * 20;
            });
            Invoke(nameof(OnDead), 3);
        }
       
    }


   
    public void OnDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<Charactor>().onHit(player.playerProperties.Damage2);
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);
        }
        if (collision.CompareTag("skill"))
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);

        }
    }
}
