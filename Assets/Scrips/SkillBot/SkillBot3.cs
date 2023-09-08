using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBot3 : MonoBehaviour
{
    public DataEneMy dataEneMy;
    public Rigidbody2D rb;
    public GameObject[] hitVFX;
    float damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }

    public void OnInit()
    {
        rb.velocity = transform.right * 20f;
        Invoke(nameof(OnDestroy), 4f);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void SetDame3(float dame)
    {
        damage = dame;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
            GameObject hitvfx3 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            if (!PlayerController.playerData.Immortal)
            {
                collision.GetComponent<Charactor>().OnHit(damage);
            }
            OnDestroy();
            Destroy(hitvfx, 1);
            Destroy(hitvfx2, 1);
            Destroy(hitvfx3, 1);
        }
        if (collision.CompareTag("skill"))
        {
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            OnDestroy();
            Destroy(hitvfx, 1);
            Destroy(hitvfx2, 1);
        }
    }
}
