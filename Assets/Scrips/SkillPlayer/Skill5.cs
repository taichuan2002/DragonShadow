using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] hitVFX;
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
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
            GameObject hitvfx3 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            Vector3 largerScale = new Vector2(2, 2);
            hitvfx.transform.localScale = largerScale;
            onDead();
            Destroy(hitvfx, 1);
            Destroy(hitvfx2, 1);
            Destroy(hitvfx3, 1);
        }
    }
}
