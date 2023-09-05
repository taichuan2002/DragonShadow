using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject hitVFXDead;
    float Dame;
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
    public void SetDame(float dame)
    {
        Dame = dame;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<CharactorEnemy>().OnHit(Dame);
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            onDead();
            Destroy(hitvfx, 1);
        }
    }
}
