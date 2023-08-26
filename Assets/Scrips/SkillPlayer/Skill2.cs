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
    public GameObject hitVFXDead;

    private int currentWaypointIndex = 0;
    float Dame;

    private void Update()
    {

        rb.velocity = transform.right * 15;
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
            collision.GetComponent<CharactorEnemy>().OnHit(PlayerController.playerData.DamageAttack2);
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);
        }
        if (collision.CompareTag("skillEnemy"))
        {
            GameObject hitvfx = Instantiate(hitVFXDead, transform.position, transform.rotation);
            OnDead();
            Destroy(hitvfx, 2);
        }
    }
}
