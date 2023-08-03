using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textt : MonoBehaviour
{
    public Transform[] controlPoints;
    public float moveSpeed = 5f;

    private int currentWaypointIndex = 0;
    private float t = 0f;


    void Start()
    {
        Vector2 start = transform.position;
        transform.position = controlPoints[currentWaypointIndex].position;

    }

    private void Update()
    {
        if (currentWaypointIndex >= controlPoints.Length - 2)
        {
            return;
        }
        t += Time.deltaTime;
        if (t >= 1f)
        {
            t = 1f;
            currentWaypointIndex += 2;
        }

        Vector2 point = BezierPoint(t, controlPoints[0].position, controlPoints[1].position, controlPoints[2].position);

        transform.position = point;

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

}
