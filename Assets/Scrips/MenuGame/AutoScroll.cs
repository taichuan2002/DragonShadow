using DanielLochner.Assets.SimpleScrollSnap;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public int itemCount = 10;
    public float itemHeight = 100f;
    public float spacing = 10f;
    bool isCheck = false;
    int dead, level;
    float offsetY, offsetY2, offsetY3, offsetY4;
    private void Start()
    {
        level = PlayerPrefs.GetInt("levelMap");
        dead = PlayerPrefs.GetInt("isDead");
        offsetY = (level - 1) * (itemHeight) - content.rect.height / 2 + itemHeight / 2;
        offsetY2 = level * (itemHeight) - content.rect.height / 2 + itemHeight / 2;
        offsetY3 = (level + 2) * (itemHeight) - content.rect.height / 2 + itemHeight / 2;
        offsetY4 = level * (itemHeight) - content.rect.height / 2 + itemHeight / 2;
        if (dead == 0)
        {
            Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY);
            content.localPosition = targetPosition;
        }
        else
        {
            Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY3);
            content.localPosition = targetPosition;
        }
    }
    private void Update()
    {

    }
    public IEnumerator ScrollItem(int index)
    {
        level = PlayerPrefs.GetInt("levelMap");


        Debug.Log(level);
        Debug.Log(dead);
        dead = PlayerPrefs.GetInt("isDead");
        float contentHeight = itemCount * (itemHeight + spacing);
        content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight);
        if (dead == 0)
        {
            Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY);
            content.localPosition = targetPosition;
            yield return new WaitForSeconds(1.5f);
            content.DOAnchorPosY(-offsetY2, 2);
        }
        else
        {
            Vector2 targetPosition2 = new Vector2(content.localPosition.x, -offsetY3);
            content.localPosition = targetPosition2;
            yield return new WaitForSeconds(1.5f);
            content.DOAnchorPosY(-offsetY4, 2);
            PlayerPrefs.SetInt("isDead", 0);
            PlayerPrefs.Save();
        }
    }

    public void ItemCenter()
    {
        StartCoroutine(ScrollItem(level));
    }


}
