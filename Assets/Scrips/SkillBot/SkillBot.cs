using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBot : MonoBehaviour
{

    public Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }

    public void OnInit()
    {
        rb.velocity = -transform.right * 10f;
        Invoke(nameof(OnDestroy), 4f);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Charactor>().onHit(15);
            OnDestroy();
        }
    }
}
