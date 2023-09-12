using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour
{
    [SerializeField] Image[] _imgPlayer;
    [SerializeField] Sprite[] _spritePlayerLoad;
    private void Update()
    {
        int pl = PlayerPrefs.GetInt("idPlayer");
        _imgPlayer[0].sprite = _spritePlayerLoad[pl];
        _imgPlayer[1].sprite = _spritePlayerLoad[pl];
    }
}
