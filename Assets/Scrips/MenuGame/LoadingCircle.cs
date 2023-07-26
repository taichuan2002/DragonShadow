using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private RectTransform rectComponent;
    private float speed = 200f;

    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectComponent.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
