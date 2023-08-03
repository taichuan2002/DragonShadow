using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject hitVFXDead;
    public DataPlayer player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public void OnInit()
    {
        rb.velocity = transform.right * 15f;
        Invoke(nameof(onDead), 3f);
    }

    public void onDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<Charactor>().onHit(player.DamageAttack4);
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            onDead();
            Destroy(hitvfx, 1);
        }
        if (collision.CompareTag("skill"))
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            onDead();
            Destroy(hitvfx, 1);
        }
    }
}
