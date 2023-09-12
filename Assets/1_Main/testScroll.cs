using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AirFishLab.ScrollingList.ListBank;

public class testScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public int itemCount = 10;
    public float itemHeight = 100f;
    public float spacing = 10f;
    void Start()
    {
        float contentHeight = itemCount * (itemHeight + spacing) - spacing;
        content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight);
    }

    public IEnumerator ScrollItem(int index)
    {
        float offsetY = index * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;
        float offsetY2 = (index + 1) * (itemHeight + spacing) - content.rect.height / 2 + itemHeight / 2;

        Vector2 targetPosition = new Vector2(content.localPosition.x, -offsetY);
        content.localPosition = targetPosition;
        yield return new WaitForSeconds(2);
        content.DOAnchorPosY(-offsetY2, 2);

    }

    public void ItemCenter(int item)
    {
        StartCoroutine(ScrollItem(item));
    }
}
