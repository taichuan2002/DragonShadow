using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class spinnerPlayer : MonoBehaviour
{
    public Transform[] obj;
    public Sprite[] sprites;
    public Image[] _img;
    bool isCheck = true;
    private int currentIndex = 0;
    private Vector3 screenCenter;

    public DataPlayer[] player;

    private Vector3[] initialPositions;
    private Vector3 scrollViewCenterPosition;
    private void Start()
    {
        OnInit();
        if (obj.Length > 0)
        {
            scrollViewCenterPosition = obj[0].parent.position;
        }
    }

    public void OnInit()
    {
        _img[0].sprite = sprites[0];
        _img[1].sprite = sprites[1];
        _img[2].sprite = sprites[2];
        _img[3].sprite = sprites[3];
        _img[4].sprite = sprites[4];
        initialPositions = new Vector3[obj.Length];
        for (int i = 0; i < obj.Length; i++)
        {
            initialPositions[i] = obj[i].position;
        }
    }
    public void nextPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            float distanceToCenter = Vector3.Distance(
                Camera.main.WorldToScreenPoint(obj[0].position), screenCenter);
            obj[0].DOMove(obj[4].position, 1).OnComplete(() => UpdateTransformOrder());
            obj[4].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[1].position, 1);
            obj[1].DOMove(obj[0].position, 1);
            Debug.Log("Khoảng cách đến trung tâm: " + distanceToCenter);
        }
    }
    public void backPlayer()
    {
        if (isCheck)
        {
            isCheck = false;
            float distanseToCenter = Vector3.Distance(
                Camera.main.WorldToScreenPoint(obj[0].position), screenCenter);
            obj[0].DOMove(obj[1].position, 1).OnComplete(() => UpdateTransformOrder());
            obj[1].DOMove(obj[2].position, 1);
            obj[2].DOMove(obj[3].position, 1);
            obj[3].DOMove(obj[4].position, 1);
            obj[4].DOMove(obj[0].position, 1);
            Debug.Log("Khoảng cách đến trung tâm: " + distanseToCenter);
        }
        
    }

    private void UpdateTransformOrder()
    {
        Transform temp = obj[0];
        for (int i = 0; i < obj.Length - 1; i++)
        {
            obj[i] = obj[i + 1];
        }
        obj[obj.Length - 1] = temp;

        currentIndex  = (currentIndex + obj.Length -1) % obj.Length;

        for(int i =0; i < obj.Length; i++)
        {
            if(i == currentIndex)
            {
                obj[i].SetSiblingIndex(0);
            }
            else
            {
                obj[i].SetSiblingIndex(i);
            }

        }
        isCheck = true;
    }
    private float GetDistanceToCenter(Transform targetTransform)
    {
        return Vector3.Distance(targetTransform.position, scrollViewCenterPosition);
    }
}
