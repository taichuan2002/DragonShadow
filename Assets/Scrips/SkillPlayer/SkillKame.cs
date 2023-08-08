using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillKame : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation targetBot;
    public Rigidbody2D rb;
    public GameObject hitVFXDead;
    public DataGoku player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        OnInit();
    }
    public void OnInit()
    {
        Vector2 targetPosition = (targetBot.transform.position - transform.position).normalized;
        rb.velocity = targetPosition * 15f;
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
            collision.GetComponent<Charactor>().onHit(player.DamageAttack1);
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            Destroy(hitvfx, 1);
            onDead();
        }
        if (collision.CompareTag("skill"))
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            onDead();
            Destroy(hitvfx, 1);
        }
    }
}
