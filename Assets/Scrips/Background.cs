using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Texture2D[] backgroundTextures;
    public float scrollSpeed = 0.5f;

    private Renderer backgroundRenderer;
    private Vector2 offset;
    private int currentTextureIndex = 0;

    private void Start()
    {
        backgroundRenderer = GetComponent<Renderer>();
        currentTextureIndex = Random.Range(0, backgroundTextures.Length);
        backgroundRenderer.material.mainTexture = backgroundTextures[currentTextureIndex];
        offset = new Vector2(0, 0);
    }

    private void Update()
    {
        offset.x += Time.deltaTime * scrollSpeed;
        backgroundRenderer.material.mainTextureOffset = offset;
    }
}
