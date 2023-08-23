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
    public Vector3[] Points;
    public float moveSpeed = 5f;
    public float speed = 5f;

    private int currentWaypointIndex = 0;
    private float t = 0f;
    int randomPoint;
    float Dame;
    void Start()
    {
        OnInit();
        transform.position = Points[0];
    }


    private void Update()
    {
        if (currentWaypointIndex >= Points.Length - 2)
        {
            return;
        }
        t += Time.deltaTime;
        if (t >= 1f)
        {
            t = 1f;
            currentWaypointIndex += 2;
        }

        Vector3 point = BezierPoint(t, Points[0], Points[randomPoint],
            Points[10]);
        transform.position = point;

        Vector3 skillDirection = GetSkillDirection(t);

        float angle = Mathf.Atan2(skillDirection.y, skillDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        rb.velocity = transform.right * 15;

        Invoke(nameof(OnDead), 3);
    }
    public void OnInit()
    {
        Points[0] = transform.position;
        Points[1] = new Vector3(transform.position.x, 5f);
        Points[2] = new Vector3(transform.position.x, 3.75f);
        Points[3] = new Vector3(transform.position.x, 2.5f);
        Points[4] = new Vector3(transform.position.x, 1.25f);
        Points[5] = new Vector3(transform.position.x, 0f);
        Points[6] = new Vector3(transform.position.x, -1.25f);
        Points[7] = new Vector3(transform.position.x, -2.5f);
        Points[8] = new Vector3(transform.position.x, -3.75f);
        Points[9] = new Vector3(transform.position.x, -5f);
        Points[10] = new Vector3(transform.position.x + 15, transform.position.y);

        rb = GetComponent<Rigidbody2D>();
        randomPoint = UnityEngine.Random.Range(1, 10);

    }

    public void SetDame(float dame)
    {
        Dame = dame;
    }

    Vector2 BezierPoint(float t, Vector2 a, Vector2 b, Vector2 c)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;

        Vector2 p = uu * a;
        p += 2f * u * t * b;
        p += tt * c;

        return p;
    }
    private Vector3 GetSkillDirection(float t)
    {
        Vector3 point1 = BezierPoint(t, Points[0], Points[randomPoint], Points[10]);
        Vector3 point2 = BezierPoint(t + 0.1f, Points[0], Points[randomPoint], Points[10]);
        Vector3 direction = point2 - point1;
        direction.Normalize();
        return direction;
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
