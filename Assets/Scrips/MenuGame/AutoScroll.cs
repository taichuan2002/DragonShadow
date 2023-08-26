using DanielLochner.Assets.SimpleScrollSnap;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class AutoScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public int itemCount = 10;
    public float itemHeight = 100f;
    public float spacing = 10f;
    bool isCheck = false;

    public IEnumerator ScrollItem(int index)
    {
        float contentHeight = itemCount * (itemHeight + spacing) - spacing;
        content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight);
        int dead = PlayerPrefs.GetInt("isDead");
        if (dead == 0)
        {
            float offsetY = (index - 1) * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;
            float offsetY2 = index * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;
            Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY);
            content.localPosition = targetPosition;
            yield return new WaitForSeconds(1.5f);
            content.DOAnchorPosY(-offsetY2, 2);
        }
        else
        {
            float offsetY = (index + 2) * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;
            float offsetY2 = index * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;
            Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY);
            content.localPosition = targetPosition;
            yield return new WaitForSeconds(1.5f);
            content.DOAnchorPosY(-offsetY2, 2);
            PlayerPrefs.SetInt("isDead", 0);
        }
    }

    public void ItemCenter()
    {
        int level = PlayerPrefs.GetInt("levelMap");
        StartCoroutine(ScrollItem(level));
    }

    private void OnEnable()
    {
        ItemCenter();
    }

}
