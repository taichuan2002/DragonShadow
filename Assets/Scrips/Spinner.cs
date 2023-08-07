using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spinner : MonoBehaviour
{
    [SerializeField] private Button btnSpiner;
    [SerializeField] private GameObject objGokuMain;
    [SerializeField] private GameObject objCellMain;

    private float startTime;
    private float pointAB;
    private bool isCheck = true;
    private float duration = 1.5f;

    private Vector2 pointA = new Vector2(-5.1f, 0);
    private Vector2 pointB = new Vector2(-4.3f, -0.6f);
    private Vector2 pointC = new Vector2(5.1f, 0);
    private Vector2 pointD = new Vector2(4.3f, -0.6f);
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        btnSpiner.transform.rotation *= Quaternion.Euler(0f, 0f, -120f * Time.deltaTime);
        animGokumain();
        animCellmain();
        anim();
    }

    public void animGokumain()
    {
        float disCovered = (Time.time - startTime) / 2;
        if (isCheck)
        {
            objGokuMain.transform.position = Vector3.Lerp(pointA, pointB, disCovered);
        }
        else
        {
            objGokuMain.transform.position = Vector3.Lerp(pointB, pointA, disCovered);
        }

        if (disCovered >= 1f)
        {
            isCheck = !isCheck;
            startTime = Time.time;
            duration = isCheck ? 1.5f : 2f;
        }
    }
    public void animCellmain()
    {
        float disCovered = (Time.time - startTime) / 2;
        if (isCheck)
        {
            objCellMain.transform.position = Vector3.Lerp(pointC, pointD, disCovered);
        }
        else
        {
            objCellMain.transform.position = Vector3.Lerp(pointD, pointC, disCovered);
        }

        if (disCovered >= 1f)
        {
            isCheck = !isCheck;
            startTime = Time.time;
            duration = isCheck ? 1.5f : 2f;
        }
    }
    public void anim()
    {

    }
}
