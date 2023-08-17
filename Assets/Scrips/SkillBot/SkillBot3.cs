using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBot3 : MonoBehaviour
{
    public DataEneMy dataEneMy;
    public Rigidbody2D rb;
    float damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }

    public void OnInit()
    {
        rb.velocity = transform.right * 15f;
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
            int center = PlayerPrefs.GetInt("IdEnemy");
            collision.GetComponent<Charactor>().OnHit(damage);
            OnDestroy();
        }
        if (collision.CompareTag("skill"))
        {
            OnDestroy();
        }
    }
}
