using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject[] backgrounds;
    [SerializeField] Image[] imgBackgrounds;
    [SerializeField] Sprite[] sprites;
    float screenWidth;

    private void Start()
    {
        float screenAspect = Camera.main.aspect;
        float cameraHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenAspect * cameraHeight;
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                imgBackgrounds[0].sprite = sprites[0];
                imgBackgrounds[1].sprite = sprites[1];
                break;
            case 1:
                imgBackgrounds[0].sprite = sprites[2];
                imgBackgrounds[1].sprite = sprites[3];
                break;
            case 2:
                imgBackgrounds[0].sprite = sprites[4];
                imgBackgrounds[1].sprite = sprites[5];
                break;
            case 3:
                imgBackgrounds[0].sprite = sprites[6];
                imgBackgrounds[1].sprite = sprites[7];
                break;
        }
    }
    private void Update()
    {
        float t = Time.deltaTime;
        backgrounds[0].transform.position += new Vector3(-10 * t, 0);
        backgrounds[1].transform.position += new Vector3(-10 * t, 0);
        if (backgrounds[0].transform.position.x < -screenWidth)
        {
            backgrounds[0].transform.position = new Vector3(screenWidth - 0.1f, 0);
        }
        if (backgrounds[1].transform.position.x < -screenWidth)
        {
            backgrounds[1].transform.position = new Vector3(screenWidth - 0.1f, 0);
        }
    }
}
