using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testSkill2 : MonoBehaviour
{
    public GameObject skill2Prf;
    public Transform Attack;
    public Vector3[] Points;
    private float t = 0f;
    private int currentWaypointIndex = 0;
    private int randomPointUp, randomPointUp2, randomPointDown, randomPointDown2;
    bool isCheck = false;
    bool isCheckClick = false;
    bool isBtn = false;
    GameObject[] skill = new GameObject[6];
    void Start()
    {
        OnInit();
    }
    public void OnInit()
    {
        Points[0] = Attack.transform.position;
        Points[1] = new Vector3(skill2Prf.transform.position.x, 5f);
        Points[2] = new Vector3(skill2Prf.transform.position.x, 3.75f);
        Points[3] = new Vector3(skill2Prf.transform.position.x, 2.5f);
        Points[4] = new Vector3(skill2Prf.transform.position.x, 1.25f);
        Points[5] = new Vector3(skill2Prf.transform.position.x, 0f);
        Points[6] = new Vector3(skill2Prf.transform.position.x, -1.25f);
        Points[7] = new Vector3(skill2Prf.transform.position.x, -2.5f);
        Points[8] = new Vector3(skill2Prf.transform.position.x, -3.75f);
        Points[9] = new Vector3(skill2Prf.transform.position.x, -5f);
        Points[10] = new Vector3(skill2Prf.transform.position.x + 15, skill2Prf.transform.position.y);
        Points[11] = new Vector3(skill2Prf.transform.position.x + 15, skill2Prf.transform.position.y);

        randomPointUp = UnityEngine.Random.Range(1, 3);
        randomPointUp2 = UnityEngine.Random.Range(3, 5);
        randomPointDown = UnityEngine.Random.Range(6, 8);
        randomPointDown2 = UnityEngine.Random.Range(8, 10);

    }

    void Update()
    {
        if (isBtn)
        {
            Controller();
            isBtn = false;

        }
    }
    public void SpawnSkill(bool Btn)
    {
        isBtn = Btn;

        skill[1] = Instantiate(skill2Prf, Attack.position, Attack.rotation);
        skill[2] = Instantiate(skill2Prf, Attack.position, Attack.rotation);
        skill[3] = Instantiate(skill2Prf, Attack.position, Attack.rotation);
        skill[4] = Instantiate(skill2Prf, Attack.position, Attack.rotation);
        skill[5] = Instantiate(skill2Prf, Attack.position, Attack.rotation);
        skill[1].transform.position = Points[0];
        skill[2].transform.position = Points[0];
        skill[3].transform.position = Points[0];
        skill[4].transform.position = Points[0];
        skill[5].transform.position = Points[0];
        isCheck = true;
    }
    public void Controller()
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

        Vector3 point = BezierPoint(t, Points[0], Points[randomPointUp], Points[10]);
        Vector3 point2 = BezierPoint(t, Points[0], Points[randomPointUp2], Points[10]);
        Vector3 point3 = BezierPoint(t, Points[0], Points[randomPointDown], Points[10]);
        Vector3 point4 = BezierPoint(t, Points[0], Points[randomPointDown2], Points[10]);
        Vector3 point5 = BezierPoint(t, Points[0], Points[5], Points[10]);

        if (isCheck)
        {
            skill[1].transform.position = point;
            skill[2].transform.position = point2;
            skill[3].transform.position = point5;
            skill[4].transform.position = point3;
            skill[5].transform.position = point4;
            isCheck = false;
        }

        Vector3 skillDirection = GetSkillDirectionUp(t);
        Vector3 skillDirection2 = GetSkillDirectionDown(t);
        float angle = Mathf.Atan2(skillDirection.y, skillDirection.x) * Mathf.Rad2Deg;
        skill2Prf.transform.rotation = Quaternion.Euler(0, 0, angle);
        float angle2 = Mathf.Atan2(skillDirection2.y, skillDirection2.x) * Mathf.Rad2Deg;
        skill2Prf.transform.rotation = Quaternion.Euler(0, 0, angle2);
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

    private Vector3 GetSkillDirectionUp(float t)
    {
        Vector3 point1 = BezierPoint(t, Points[0], Points[randomPointUp], Points[10]);
        Vector3 point2 = BezierPoint(t + 0.1f, Points[0], Points[randomPointUp], Points[10]);
        Vector3 direction = point2 - point1;
        direction.Normalize();
        return direction;
    }
    private Vector3 GetSkillDirectionDown(float t)
    {
        Vector3 point1 = BezierPoint(t, Points[0], Points[randomPointDown], Points[10]);
        Vector3 point2 = BezierPoint(t + 0.1f, Points[0], Points[randomPointDown], Points[10]);
        Vector3 direction = point2 - point1;
        direction.Normalize();
        return direction;
    }

}
