using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public Material mt;
    void Update()
    {
        mt.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
