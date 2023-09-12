using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurScrollview : MonoBehaviour
{
    public ScrollRect scrollRect;
    public Image img;
    public float maxBlur = 100.0f;

    private void Update()
    {
        float scrollPosition = scrollRect.normalizedPosition.y;
        float blur = Mathf.Clamp01(scrollPosition * maxBlur);
        Color blurColor = img.color;
        blurColor.a *= 1.0f - blur;
        img.color = blurColor;
    }
}
