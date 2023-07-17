using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKame : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation targetBot;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public void OnInit()
    {
        Vector2 targetPosition = (targetBot.transform.position - transform.position).normalized;
        rb.velocity = targetPosition * 15f;
        Invoke(nameof(OnDestroy), 3f);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<Charactor>().onHit(15);
            OnDestroy();
        }
        if (collision.CompareTag("skill"))
        {
            OnDestroy();
        }
    }
}
