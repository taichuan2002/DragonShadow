using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject[] hitVFX;


    private int currentWaypointIndex = 0;
    float Dame;

    private void Update()
    {
        rb.velocity = transform.right * 20;
        Invoke(nameof(OnDead), 3);
    }

    public void SetDame(float dame)
    {
        Dame = dame;
    }


    public void OnDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bot"))
        {
            collision.GetComponent<CharactorEnemy>().OnHit(Dame);
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[1], transform.position, transform.rotation);
            GameObject hitvfx3 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);
            Destroy(hitvfx2, 2);
            Destroy(hitvfx3, 2);
        }
        if (collision.CompareTag("skillEnemy"))
        {
            GameObject hitvfx = Instantiate(hitVFX[0], transform.position, transform.rotation);
            GameObject hitvfx2 = Instantiate(hitVFX[2], transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);
            Destroy(hitvfx2, 2);
        }
    }
}
